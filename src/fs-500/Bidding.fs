namespace Fivehundred

type Bidding(playersCards) =
    let playersCards = playersCards

    member this.NextBid() =
        let bid = 
            List.toSeq playersCards
            |> Seq.pick (fun card -> 
                match card with
                | Joker -> Some(NoTrumps(6))
                | Ace(suit) -> Some(Bid(6, suit))
                | _ -> Option.None
            )
        match bid with 
        | bid -> bid
        | _ -> Pass