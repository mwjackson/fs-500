namespace Fivehundred.Tests

open Fivehundred

open NUnit.Framework

[<TestFixture>]
type DeckTests() = 

    [<Test>][<Ignore>]
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

    [<Test>]
    member test.dealing_two_cards_should_return_two_cards_that_are_different() = 
        let deck = new Deck()
        let cards = deck.Deal(2)
        Assert.That(cards.Item(0), Is.Not.EqualTo(cards.Item(1)))

    [<Test>]
    member test.card_tostring_should_describe_what_card_it_is() =
        let card = Ace(Suit.Hearts)
        Assert.That(card.ToString(), Is.EqualTo("Ace of Hearts")) 