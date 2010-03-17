namespace Fivehundred

type Game() =
    let deck = new Deck()
    let cards = deck.Deal()

    member this.Player1 = Player("One", cards |> Seq.skip 0 |> Seq.take 10 |> Seq.toList)
    member this.Player2 = Player("Two", cards |> Seq.skip 10 |> Seq.take 10 |> Seq.toList)
    member this.Player3 = Player("Three", cards |> Seq.skip 20 |> Seq.take 10 |> Seq.toList)
    member this.Player4 = Player("Four", cards |> Seq.skip 30 |> Seq.take 10|> Seq.toList)

    member this.Kitty = cards |> Seq.skip 40 |> Seq.take 3 |> Seq.toList
