module Day03

open System
open System.Text.RegularExpressions
open Common.Parsing
open Common.Casting

let notSymbolRx = Regex(@"\d|\.", RegexOptions.Compiled)
let numberRx = Regex(@"\d+", RegexOptions.Compiled)
let gearRx = Regex(@"\*", RegexOptions.Compiled)
let digitRx = Regex(@"\d", RegexOptions.Compiled)

type Number = {Value: int; Row: int; ColumnStart: int; ColumnStop: int; }


let isSymbol (lookup: char array array) ((x, y): int*int) =
    not (notSymbolRx.IsMatch(lookup.[x].[y].ToString()))

let isValidCoordinate (lookup: char array array) ((x, y): int*int) =
    let sampleRow = Array.head lookup
    match (x,y) with
    | (x,y) when x < 0 -> false //out of bounds
    | (x,y) when y < 0 -> false //out of bounds
    | (x,y) when x >= lookup.Length -> false //out of bounds
    | (x,y) when y >= sampleRow.Length -> false //out of bounds
    | (x,y) -> isSymbol lookup (x,y)

let getAdjacentCoordinates x y = [
        (x+1,y-1); (x+1,y); (x+1,y+1);
        (x,y-1);            (x,y+1);
        (x-1,y-1); (x-1,y); (x-1,y+1)
    ]

let isPartDigit (lookup: char array array) (x: int) (y: int) =
    getAdjacentCoordinates x y |> List.exists (isValidCoordinate lookup)

let isPartNumber (lookup: char array array) (x: int) (number: Match) =
    let columns = [number.Index .. number.Index + (number.Length - 1)]
    columns |> List.exists (isPartDigit lookup x)

let getNumberInLine line =
    [for m in numberRx.Matches(line) do yield m]

let getValidNumbers (lookup: char array array) (x: int) (line: string) =
    getNumberInLine line
    |> List.filter (isPartNumber lookup x)
    |> List.map(fun m -> m.Value)
    |> List.map Int32.Parse

let part1 text =
    let lines = splitNewline text
    let lookup = lines |> Array.map toCharArray

    lines
    |> Array.toList
    |> List.mapi (getValidNumbers lookup)
    |> List.concat
    |> List.sum

let isDigit (lookup: char array array) ((x, y): int*int) =
    digitRx.IsMatch(lookup.[x].[y].ToString())

let coordinateIsDigit (lookup: char array array) (x,y) = 
    let sampleRow = Array.head lookup
    match (x,y) with
    | (x,y) when x < 0 -> false //out of bounds
    | (x,y) when y < 0 -> false //out of bounds
    | (x,y) when x >= lookup.Length -> false //out of bounds
    | (x,y) when y >= sampleRow.Length -> false //out of bounds
    | (x,y) -> isDigit lookup (x,y)

let getAdjacentDigits (lookup: char array array) (gear: Match) x =
    let y = gear.Index
    getAdjacentCoordinates x y
    |> List.filter (coordinateIsDigit lookup)

let getNumberFromCoordinates (numbers: Number list) (x,y) =
    numbers
    |> List.filter(fun n -> n.Row = x)
    |> List.filter(fun n -> y >= n.ColumnStart)
    |> List.filter(fun n -> y <= n.ColumnStop)
    |> List.head

let calculateRatio (numbers: int list) =
    (List.head numbers) * (List.last numbers)

let getRatio (lookup: char array array) (numbers: Number list) x (gear: Match) =
    let partNumbers =
        getAdjacentDigits lookup gear x
        |> List.map (getNumberFromCoordinates numbers)
        |> List.distinct
        |> List.map(fun x -> x.Value)
    if List.length partNumbers = 2 then calculateRatio partNumbers else 0
    
let getGearRatios (lookup: char array array) (numbers: Number list) (x: int) (line: string) =
    [for m in gearRx.Matches(line) do yield m]
    |> List.map (getRatio lookup numbers x)
    
let matchToNumber row (numberMatch: Match) = {
    Value = Int32.Parse numberMatch.Value;
    Row = row; ColumnStart = numberMatch.Index;
    ColumnStop = numberMatch.Index + (numberMatch.Length - 1);
    }

let parseNumberInLine row line =
    getNumberInLine line |> List.map (matchToNumber row)

let part2 text =
    let lines = splitNewline text
    let lookup = lines |> Array.map toCharArray
    let numbers = lines |> Array.toList |> List.mapi parseNumberInLine |> List.concat
    
    lines |> Array.toList
    |> List.mapi (getGearRatios lookup numbers)
    |> List.concat
    |> List.sum