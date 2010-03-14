namespace Fivehundred.Tests

open Fivehundred

open NUnit.Framework

type Player(name, cards) = 
    member this.Name = name
    member this.Cards = cards

type Game() =
    let deck = new Deck()
    let cards = deck.Deal()

    member this.Player1 = Player("One", cards |> Seq.skip 0 |> Seq.take 10 |> Seq.toList)
    member this.Player2 = Player("Two", cards |> Seq.skip 10 |> Seq.take 10 |> Seq.toList)
    member this.Player3 = Player("Three", cards |> Seq.skip 20 |> Seq.take 10 |> Seq.toList)
    member this.Player4 = Player("Four", cards |> Seq.skip 30 |> Seq.take 10|> Seq.toList)

    member this.Kitty = cards |> Seq.skip 40 |> Seq.take 3 |> Seq.toList

[<TestFixture>]
type GameTests() = 

    [<Test>]
    member test.a_game_should_have_four_players() = 
        let game = new Game()
        Assert.That(game.Player1, Is.Not.Null)
        Assert.That(game.Player2, Is.Not.Null)
        Assert.That(game.Player3, Is.Not.Null)
        Assert.That(game.Player4, Is.Not.Null)

    [<Test>]
    member test.dealing_should_deal_10_cards_to_each_player() =
        let game = new Game()
        Assert.That(game.Player1.Cards.Length, Is.EqualTo(10))
        Assert.That(game.Player2.Cards.Length, Is.EqualTo(10))
        Assert.That(game.Player3.Cards.Length, Is.EqualTo(10))
        Assert.That(game.Player4.Cards.Length, Is.EqualTo(10))

    [<Test>]
    member test.dealing_should_deal_different_hands_to_each_player() =
        let game = new Game()
        Assert.That(game.Player1.Cards, Is.Not.EqualTo(game.Player2.Cards), "Player 1 = Player 2")
        Assert.That(game.Player2.Cards, Is.Not.EqualTo(game.Player3.Cards), "Player 2 = Player 3")
        Assert.That(game.Player3.Cards, Is.Not.EqualTo(game.Player4.Cards), "Player 3 = Player 4")
        Assert.That(game.Player4.Cards, Is.Not.EqualTo(game.Player1.Cards), "Player 4 = Player 1")

    [<Test>]
    member test.dealing_should_deal_three_cards_to_the_kitty() =
        let game = new Game()
        Assert.That(game.Kitty.Length, Is.EqualTo(3))