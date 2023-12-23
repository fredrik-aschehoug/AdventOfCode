module Day07.Part1

open System
open Common.Parsing
open Common.Casting
open Day07.Common


let parseLabel label =
    match label with
    | "A" -> 14
    | "K" -> 13
    | "Q" -> 12
    | "J" -> 11
    | "T" -> 10
    | x -> Int32.Parse x

let isNOfAKind (text: char list) (n: int) =
    text
    |> List.groupBy (fun x -> x)
    |> List.exists (fun (x,y) -> y.Length = n)

let isFiveOfAKind (text: char list) =
    let distinct = text|> List.distinct
    distinct.Length = 1

let isFourOfAKind (text: char list) = isNOfAKind text 4

let isFullHouse (text: char list) =
    let isOfKind = isNOfAKind text
    isOfKind 3 && isOfKind 2

let isThreeOfAKind (text: char list) = isNOfAKind text 3

let isTwoPair (text: char list) =
    let pairs = text |> List.groupBy (fun x -> x) |> List.filter(fun (x,y) -> y.Length = 2)
    pairs.Length = 2

let isPair (text: char list) = isNOfAKind text 2

let calculateHand labels =
    let calculated = [
        isFiveOfAKind labels;
        isFourOfAKind labels;
        isFullHouse labels;
        isThreeOfAKind labels;
        isTwoPair labels;
        isPair labels;
        true
    ]
    let points = [0 .. 6] |> List.rev
    let (index, _)=  List.zip points calculated |> List.find (fun (i, x) -> x)
    let result = enum<HandType> index
    result
    
let parseHand text =
    let parts = splitText " " text
    let labelChars = parts |> Array.head |> toCharList
    let bid = Int32.Parse (Array.last parts)
    let handType = calculateHand labelChars
    let labels = labelChars |> List.map (fun x -> x.ToString()) |> List.map parseLabel

    { defaultHand with Bid = bid; Type = handType; Original = (Array.head parts); Labels = labels}

let main text =
    let hands =
        text |> splitNewline
        |> Array.toList
        |> List.map parseHand
    let ranks = [1 .. hands.Length] |> List.rev
    let sorted = hands |> List.sortWith handComparer |> List.sortByDescending (fun x -> x.Type)
    
    List.zip ranks sorted
    |> List.map setRank
    |> List.map getScore
    |> List.sum
