﻿namespace Fivehundred.Tests

open Fivehundred

open NUnit.Framework

[<TestFixture>]
type BiddingTests() =

    [<Test>]
    member test.a_player_with_no_ace_or_joker_or_jack_should_pass() =
        let playersCards = [ Value(8, Hearts); Value(9, Hearts); Queen(Hearts); ]
        let bidding = new Bidding(playersCards, [])
        let bid = bidding.NextBid()
        Assert.That(bid, Is.EqualTo(Pass))
   
    [<Test>]
    member test.a_player_with_an_ace_should_bid_six_of_that_suit() =
        let playersCards = [ Ace(Hearts) ]
        let bidding = new Bidding(playersCards, [])
        let bid = bidding.NextBid()
        Assert.That(bid, Is.EqualTo(Bid(6, Hearts)))

    [<Test>]
    member test.a_player_with_joker_should_bid_six_no_trumps() =
        let playersCards = [ Joker ]
        let bidding = new Bidding(playersCards, [])
        let bid = bidding.NextBid()
        Assert.That(bid, Is.EqualTo(NoTrumps(6)))
        
    [<Test>]
    member test.a_player_with_joker_and_an_ace_should_bid_six_no_trumps() =
        let playersCards = [ Ace(Hearts); Joker ]
        let bidding = new Bidding(playersCards, [])
        let bid = bidding.NextBid()
        Assert.That(bid, Is.EqualTo(NoTrumps(6)))

    [<Test>]
    member test.a_player_with_previous_bid_of_highest_six_bid_should_pass_if_they_only_hold_an_ace() =
        let previousBids = [ Bid(6, Hearts) ]
        let playersCards = [ Ace(Clubs); ]
        let bidding = new Bidding(playersCards, previousBids)
        let bid = bidding.NextBid()
        Assert.That(bid, Is.EqualTo(Pass))

    [<Test>]
    member test.a_player_whose_partner_has_bid_six_and_holds_a_bower_should_bid_seven() =
        let previousBids = [ Bid(6, Hearts); Bid(6, Diamonds) ]
        let playersCards = [ Jack(Diamonds); ]
        let bidding = new Bidding(playersCards, previousBids)
        let bid = bidding.NextBid()
        Assert.That(bid, Is.EqualTo(Bid(7, Diamonds)))

[<TestFixture>]
type BidSortTests() =
   
    [<Test>]
    member test.a_bid_of_higher_value_should_be_higher_than_a_bid_of_lesser_value() =
        let bids = [ Bid(6, Hearts); Bid(8, Hearts); Bid(7, Hearts) ]
        let bidSort = new BidSort()
        let result = bids |> List.sortWith (fun a b -> bidSort.Sort(a, b))

        let expected = [ Bid(8, Hearts); Bid(7, Hearts); Bid(6, Hearts)]
        Assert.That(result, Is.EqualTo(expected))

    [<Test>]
    member test.a_bid_of_higher_value_should_be_higher_then_a_notrumps_of_lesser_value() =
        let bids = [ NoTrumps(6); Bid(8, Hearts); Bid(7, Hearts) ]
        let bidSort = new BidSort()
        let result = bids |> List.sortWith (fun a b -> bidSort.Sort(a, b))
        
        let expected = [ Bid(8, Hearts); Bid(7, Hearts); NoTrumps(6)]
        Assert.That(result, Is.EqualTo(expected))

    [<Test>]
    member test.a_notrumps_of_same_value_should_be_higher_then_a_bid_of_same_value() =
        let bids = [ Bid(6, Hearts); Bid(6, Diamonds); NoTrumps(6);]
        let bidSort = new BidSort()
        let result = bids |> List.sortWith (fun a b -> bidSort.Sort(a, b))
        
        let expected = [ NoTrumps(6); Bid(6, Hearts); Bid(6, Diamonds) ]
        Assert.That(result, Is.EqualTo(expected))

    [<Test>]
    member test.a_hearts_of_same_value_should_be_higher_than_a_diamond() =
        let bids = [ Bid(6, Diamonds); Bid(6, Hearts); ]
        let bidSort = new BidSort()
        let result = bids |> List.sortWith (fun a b -> bidSort.Sort(a, b))
        
        let expected = [ Bid(6, Hearts); Bid(6, Diamonds) ]
        Assert.That(result, Is.EqualTo(expected))

    [<Test>]
    member test.a_diamonds_of_same_value_should_be_higher_than_a_clubs() =
        let bids = [ Bid(6, Clubs); Bid(6, Diamonds); ]
        let bidSort = new BidSort()
        let result = bids |> List.sortWith (fun a b -> bidSort.Sort(a, b))
        
        let expected = [ Bid(6, Diamonds); Bid(6, Clubs) ]
        Assert.That(result, Is.EqualTo(expected))

        
    [<Test>]
    member test.a_clubs_of_same_value_should_be_higher_than_a_spades() =
        let bids = [ Bid(6, Spades); Bid(6, Clubs); ]
        let bidSort = new BidSort()
        let result = bids |> List.sortWith (fun a b -> bidSort.Sort(a, b))
        
        let expected = [ Bid(6, Clubs); Bid(6, Spades) ]
        Assert.That(result, Is.EqualTo(expected))