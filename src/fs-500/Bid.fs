namespace Fivehundred

type Bid =
    | OpenMisere
    | Misere
    | Bid of int * Suit
    | NoTrumps of int
    | Pass

    override this.ToString() =
        match this with 
        | OpenMisere -> "Open Misere"
        | Misere -> "Misere"
        | Bid(value, suit) -> value.ToString() + " of " + suit.ToString()
        | NoTrumps(value) -> value.ToString() + " No Trumps"
        | Pass -> "Pass"