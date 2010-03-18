namespace Fivehundred

type BidSort() =
    
    member this.Sort(bid1:Bid, bid2:Bid) =
        match bid1, bid2 with
        | Bid(value1, _), Bid(value2, _) -> value2-value1
        | (NoTrumps(value1), Bid(value2, _)) 
        | (Bid(value2, _), NoTrumps(value1)) -> 
            if (value1 < value2) then 1 else
            if (value1 = value2) then 1 else 
            0
        | NoTrumps(value1), NoTrumps(value2) -> value1-value2
        | _ -> 0
        

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