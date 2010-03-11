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
    | Ace of Suit
    | King of Suit
    | Queen of Suit
    | Jack of Suit
    | Value of int * Suit 

    override this.ToString() =
        let string = match this:Card with
                        | Ace(suit) -> "Ace of " + suit.ToString()
                        | King(suit) -> "King of " + suit.ToString()
                        | Queen(suit) -> "Queen of " + suit.ToString()
                        | Jack(suit) -> "Jack of " + suit.ToString()
                        | Value(value, suit) -> value.ToString() + " of " + suit.ToString()
        string

type Deck() =
    
    let deck = 
        [
            for suit in [Suit.Spades; Suit.Clubs; Suit.Diamonds; Suit.Hearts] do
                yield Ace(suit)
                yield King(suit)
                yield Queen(suit)
                yield Jack(suit)
                for value in 2..10 do
                    yield Value(value, suit)
        ]

    member x.Deal(numberOfCards) = 
        let rnd = new Random()
        List.init<Card> numberOfCards (fun i -> deck.Item(rnd.Next(0, deck.Length)))


