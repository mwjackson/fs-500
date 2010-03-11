open System

open Fivehundred

Console.WriteLine("500 game")

let deck = new Deck()

for card in deck.Deal(25) do
    Console.WriteLine(card)

let key = Console.ReadKey()