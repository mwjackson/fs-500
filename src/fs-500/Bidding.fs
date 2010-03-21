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
        | _ -> 
            0
        

type Bidding(playersCards) =
    let playersCards = playersCards

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
        bids.Head