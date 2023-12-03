module Day03

open System
open System.Text.RegularExpressions
open Common.Parsing
open Common.Casting

let notSymbolRx = Regex(@"\d|\.", RegexOptions.Compiled)
let numberRx = Regex(@"\d+", RegexOptions.Compiled)

let isSymbol (lookup: char array array) ((x, y): int*int) =
    not (notSymbolRx.IsMatch(lookup.[x].[y].ToString()))

let isValidCoordinate (lookup: char array array) ((x, y): int*int) =
    let sampleRow = Array.head lookup
    let res =
        match (x,y) with
        | (x,y) when x < 0 -> false //out of bounds
        | (x,y) when y < 0 -> false //out of bounds
        | (x,y) when x >= lookup.Length -> false //out of bounds
        | (x,y) when y >= sampleRow.Length -> false //out of bounds
        | (x,y) -> isSymbol lookup (x,y)
    res

let isPartDigit (lookup: char array array) (x: int) (y: int) =
    let coordinates = [
        (x+1,y-1); (x+1,y); (x+1,y+1);
        (x,y-1);            (x,y+1);
        (x-1,y-1); (x-1,y); (x-1,y+1)
    ] // All adjacent coordinates
    coordinates |> List.exists (isValidCoordinate lookup)

let isPartNumber (lookup: char array array) (x: int) (number: Match) =
    let columns = [number.Index .. number.Index + (number.Length - 1)]
    columns |> List.exists (isPartDigit lookup x)

let getValidNumbers (lookup: char array array) (x: int) (line: string) =
    [for m in numberRx.Matches(line) do yield m]
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

let part2 text =
    0