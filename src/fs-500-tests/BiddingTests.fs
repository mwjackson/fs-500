namespace Fivehundred.Tests

open Fivehundred

open NUnit.Framework

[<TestFixture>]
type BiddingTests() =
   
    [<Test>]
    member test.a_player_with_an_ace_should_bid_six_of_that_suit() =
        let playersCards = [ Ace(Hearts) ]
        let bidding = new Bidding(playersCards)
        let bid = bidding.NextBid()
        Assert.That(bid, Is.EqualTo(Bid(6, Hearts)))

    [<Test>]
    member test.a_player_with_joker_should_bid_six_no_trumps() =
        let playersCards = [ Joker ]
        let bidding = new Bidding(playersCards)
        let bid = bidding.NextBid()
        Assert.That(bid, Is.EqualTo(NoTrumps(6)))