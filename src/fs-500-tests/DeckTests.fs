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

    [<Test>]
    member test.deck_should_contain_43_cards() = 
        let deck = new Deck()
        let cards = deck.Deal()
        Assert.That(cards.Length, Is.EqualTo(43))

    [<Test>]
    member test.deck_should_contain_the_bird() = 
        let deck = new Deck()
        let cards = deck.Deal()
        Assert.That(cards, NUnit.Framework.Constraints.ContainsConstraint(Joker))

    [<Test>]
    member test.deck_should_not_contain_twos() = 
        let deck = new Deck()
        let cards = deck.Deal()
        let twos = [ Value(2, Spades); Value(2, Clubs); Value(2, Diamonds); Value(2, Hearts) ] 
        for two in twos do 
            // can't differentiate nunit List.Contains with f# list
            let containsTwo = NUnit.Framework.Constraints.ContainsConstraint(two)
            Assert.That(cards, NUnit.Framework.Constraints.NotConstraint.op_LogicalNot(containsTwo))

    [<Test>]
    member test.deck_should_not_contain_threes() = 
        let deck = new Deck()
        let cards = deck.Deal()
        let threes = [ Value(3, Spades); Value(3, Clubs);  Value(3, Diamonds); Value(3, Hearts)  ] 
        for three in threes do 
            // can't differentiate nunit List.Contains with f# list
            let containsThree = NUnit.Framework.Constraints.ContainsConstraint(three)
            Assert.That(cards, NUnit.Framework.Constraints.NotConstraint.op_LogicalNot(containsThree))

    [<Test>]
    member test.deck_should_not_contain_black_fours() = 
        let deck = new Deck()
        let cards = deck.Deal()
        let fours = [ Value(3, Spades); Value(3, Clubs); ] 
        for four in fours do 
            // can't differentiate nunit List.Contains with f# list
            let containsFour = NUnit.Framework.Constraints.ContainsConstraint(four)
            Assert.That(cards, NUnit.Framework.Constraints.NotConstraint.op_LogicalNot(containsFour))