module Day04

open System
open System.Text.RegularExpressions
open Common.Parsing

let numberRx = Regex(@"\d+", RegexOptions.Compiled)

type Card = { WinningNumbers: int Set; MyNumbers: int Set}

let cleanLine (line: string) = line.Split(": ") |> Array.last

let getNumbers (text: string) =
    [for number in numberRx.Matches(text) do yield number.Value ]
    |> List.map Int32.Parse

let parseCard (line: string) =
    let parts = line.Split(" | ")
    let winningSet = Set.ofList (getNumbers (Array.head parts))
    let mySet = Set.ofList (getNumbers (Array.last parts))
    { WinningNumbers = winningSet; MyNumbers = mySet; }

let calculateCard (card: Card) =
    Set.intersect card.WinningNumbers card.MyNumbers |> Set.count

let rec getPoints sum iterator winningNumbers =
    match winningNumbers with
    | 0 -> 0
    | 1 -> 1
    | value when iterator = winningNumbers -> sum
    | value -> getPoints (sum * 2) (iterator + 1) winningNumbers

let part1 text =
    let points =
        splitNewline text
        |> Array.map cleanLine
        |> Array.map parseCard
        |> Array.map calculateCard
        |> Array.map (getPoints 1 1)
    points |> Array.sum


let part2 text =
    0