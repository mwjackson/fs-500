namespace Fivehundred

type Bid =
    | NoTrumps of int
    | Bid of int * Suit
    | Pass

    override this.ToString() =
        match this with 
//        | OpenMisere -> "Open Misere"
//        | Misere -> "Misere"
        | Bid(value, suit) -> value.ToString() + " of " + suit.ToString()
        | NoTrumps(value) -> value.ToString() + " No Trumps"
        | Pass -> "Pass"