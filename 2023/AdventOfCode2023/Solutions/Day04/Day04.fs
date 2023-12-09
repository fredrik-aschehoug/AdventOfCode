module Day04

open System
open System.Text.RegularExpressions
open Common.Parsing

let numberRx = Regex(@"\d+", RegexOptions.Compiled)

type Card = { Id: int; WinningNumbers: int Set; MyNumbers: int Set}
type CalculatedCard = { Id: int; CardsToCopy: int list; }

let cleanLine (line: string) = line.Split(": ") |> Array.last

let parseCardId (line: string) =
    let startOfLine = line.Split(":") |> Array.head
    startOfLine.Split(" ") |> Array.last |> Int32.Parse

let getNumbers (text: string) =
    [for number in numberRx.Matches(text) do yield number.Value ]
    |> List.map Int32.Parse

let parseCard (line: string) =
    let id = parseCardId line
    let parts = (cleanLine line).Split(" | ")
    let winningSet = Set.ofList (getNumbers (Array.head parts))
    let mySet = Set.ofList (getNumbers (Array.last parts))
    { Id = id; WinningNumbers = winningSet; MyNumbers = mySet; }

let calculateCard (card: Card) =
    Set.intersect card.WinningNumbers card.MyNumbers |> Set.count

let rec getPoints sum iterator winningNumbers =
    match winningNumbers with
    | 0 -> 0
    | 1 -> 1
    | value when iterator = winningNumbers -> sum
    | value -> getPoints (sum * 2) (iterator + 1) winningNumbers

let part1 =
    splitNewline
    >> Array.map parseCard
    >> Array.map calculateCard
    >> Array.map (getPoints 1 1)
    >> Array.sum

let castToCalculatedCard card =
    let points = calculateCard card
    { Id = card.Id; CardsToCopy = [card.Id + 1 .. card.Id + points]}

let getCardCopies (card: CalculatedCard) (points: int list) index count =
    let shouldAddCopies = List.contains (index + 1) card.CardsToCopy
    match shouldAddCopies with
    | true -> count + points[card.Id - 1]
    | false -> count

let folder (acc: int list) (card: CalculatedCard) =
    List.mapi (getCardCopies card acc) acc

let part2 text =
    let cards =
        splitNewline text
        |> Array.map parseCard
        |> Array.map castToCalculatedCard
        |> Array.toList
    
    let points = [for i in cards -> 1]
    
    cards
    |> List.fold folder points
    |> List.sum