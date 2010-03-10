namespace Fivehundred

open NUnit.Framework

type Suit =
    | Spades
    | Clubs
    | Diamonds
    | Hearts

type Card() =
    member x.Dummy = ""

type Deck() =
    member x.Deal(numberOfCards) = 
        List.init<Card> numberOfCards (fun i -> new Card())

[<TestFixture>]
type DeckTests() = 

    [<Test>]
    member test.dealing_should_return_a_list_of_cards() = 
        let deck = new Deck()
        let card = deck.Deal(1)
        Assert.That(card, Is.TypeOf(typedefof<List<Card>>))

    [<Test>]
    member test.dealing_one_card_should_return_a_card() = 
        let deck = new Deck()
        let cards = deck.Deal(1)
        Assert.That(cards.Length, Is.EqualTo(1))

    [<Test>]
    member test.dealing_two_cards_should_return_two_cards() = 
        let deck = new Deck()
        let cards = deck.Deal(2)
        Assert.That(cards.Length, Is.EqualTo(2))
