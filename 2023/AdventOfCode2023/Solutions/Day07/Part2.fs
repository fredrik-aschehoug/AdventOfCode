module Day07.Part2

open System
open Common.Parsing
open Common.Casting
open Day07.Common

let parseLabel label =
    match label with
    | "A" -> 14
    | "K" -> 13
    | "Q" -> 12
    | "J" -> 1
    | "T" -> 10
    | x -> Int32.Parse x

let isNOfAKind (text: char list) (n: int) =
    text
    |> List.filter (fun x -> x <> 'J')
    |> List.groupBy (fun x -> x)
    |> List.exists (fun (x,y) -> y.Length = n)

let isFiveOfAKind (text: char list) =
    let distinct = text|> List.distinct
    distinct.Length = 1 || (distinct.Length = 2 && (List.contains 'J' text))

let isFourOfAKind (text: char list) jokers =
    jokers >= 3 || isNOfAKind text (4 - jokers)

let isTwoPair (text: char list) jokers =
    let pairs = text |> List.groupBy (fun x -> x) |> List.filter(fun (x,y) -> y.Length = 2)
    let isOfKind = isNOfAKind text
    match jokers with
    | 0 -> pairs.Length = 2
    | 1 -> (isOfKind 1 && isOfKind 2)
    | _ -> true

let isFullHouse (text: char list) jokers =
    let isOfKind = isNOfAKind text
    match jokers with
    | 0 -> isOfKind 3 && isOfKind 2
    | 1 -> (isTwoPair text 0) || (isOfKind 3)
    | 2 -> (isOfKind 1 && isOfKind 2) || (isOfKind 3)
    | _ -> true

let isThreeOfAKind (text: char list) jokers = isNOfAKind text (3 - jokers)

let isPair (text: char list) jokers = isNOfAKind text 2 || jokers > 0

let calculateHand labels =
    let jokers = labels |> List.filter (fun l -> l = 'J') |> List.length
    let calculated = [
        isFiveOfAKind labels;
        isFourOfAKind labels jokers;
        isFullHouse labels jokers;
        isThreeOfAKind labels jokers;
        isTwoPair labels jokers;
        isPair labels jokers;
        true
    ]
    let points = [0 .. 6] |> List.rev
    let (index, _)=  List.zip points calculated |> List.find (fun (i, x) -> x)
    let result = enum<Day07.Common.HandType> index
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