namespace Fivehundred

type BidSort() =

    member this.SortSuit(bid1:Bid, bid2:Bid) =
        let order = [ Hearts; Diamonds; Clubs; Spades]
        match bid1, bid2 with
        | Bid(_, suit1), Bid(_, suit2) ->
            let suitIndex1 = order |> Seq.findIndex (fun suit -> suit = suit1)
            let suitIndex2 = order |> Seq.findIndex (fun suit -> suit = suit2)
            suitIndex1-suitIndex2
        | _ -> 0
    
    member this.Sort(bid1:Bid, bid2:Bid) =
        match bid1, bid2 with
        | Bid(value1, _), Bid(value2, _) -> 
            if (value1 = value2) then this.SortSuit(bid1, bid2)
            else value2-value1 
        | (NoTrumps(value1), Bid(value2, _)) 
        | (Bid(value2, _), NoTrumps(value1)) -> 
            if (value1 < value2) then 1 else
            if (value1 = value2) then 1 else 
            0
        | NoTrumps(value1), NoTrumps(value2) -> 
            value2-value1
        | Bid(_, _), nothing -> -1
        | _ -> 
            0
        

type Bidding(playersCards:List<Card>, previousBids:List<Bid>) =
    let playersCards = playersCards
    let previousBids = previousBids

    let GetAllBids() =
        [
            for card in playersCards do
                match card with 
                | Joker -> yield NoTrumps(6)
                | Ace(suit) -> yield Bid(6, suit)
                | _ -> yield Pass
        ]

    member this.NextBid() = 
        let bidSort = new BidSort()
        let bids = GetAllBids() |> List.sortWith (fun a b -> bidSort.Sort(a, b))
        match previousBids with
        | [] -> bids.Head
        | head::tail ->
            if (bidSort.Sort(bids.Head, head) < 0) then bids.Head
            else Pass
        | _ -> Pass