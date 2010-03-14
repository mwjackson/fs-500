namespace Fivehundred

open System

type Suit =
    | Spades
    | Clubs
    | Diamonds
    | Hearts

    override this.ToString() =
        match this with 
        | Spades -> "Spades"
        | Clubs -> "Clubs"
        | Diamonds -> "Diamonds"
        | Hearts -> "Hearts"

type Card = 
    | Joker
    | Ace of Suit
    | King of Suit
    | Queen of Suit
    | Jack of Suit
    | Value of int * Suit 

    override this.ToString() =
        let string = match this:Card with
                        | Joker -> "Joker"
                        | Ace(suit) -> "Ace of " + suit.ToString()
                        | King(suit) -> "King of " + suit.ToString()
                        | Queen(suit) -> "Queen of " + suit.ToString()
                        | Jack(suit) -> "Jack of " + suit.ToString()
                        | Value(value, suit) -> value.ToString() + " of " + suit.ToString()
        string

type Deck() =
    
    let deck = 
        [
            yield Joker
            for suit in [Suit.Spades; Suit.Clubs; Suit.Diamonds; Suit.Hearts] do
                yield Ace(suit)
                yield King(suit)
                yield Queen(suit)
                yield Jack(suit)
                for value in 5..10 do
                    yield Value(value, suit)
            yield Value(4, Diamonds)
            yield Value(4, Hearts)
        ]

    member x.Deal(numberOfCards) = 
        let rnd = new Random()
        List.sortWith (fun a b -> rnd.Next(-1,1)) deck
        |> Seq.take numberOfCards
        |> Seq.toList

    member x.Deal() =
        x.Deal(deck.Length)
