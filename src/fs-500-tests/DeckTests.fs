namespace Fivehundred

open NUnit.Framework

type Suit =
    | Spades
    | Clubs
    | Diamonds
    | Hearts

type Card() =
    member x.Dummy = ""

[<TestFixture>]
type DeckTests = 

    [<Test>]
    member test.dealing_one_card_should_return_a_card() = 
        let card = ""
        Assert.That(card, Is.TypeOf(typeof<Card>))
