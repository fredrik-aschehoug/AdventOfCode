module Day06

open System
open Common.Parsing
open System.Text.RegularExpressions

let numberRx = Regex(@"\d+", RegexOptions.Compiled)

let parseNumbers text =
    [for number in numberRx.Matches(text) do yield number.Value ]
    |> List.map Int32.Parse

let getResultForTime (time: int) (pressTime: int) =
    let speed = pressTime
    let timeLeft = time - pressTime
    speed * timeLeft

let getResultsForTime (time: int) =
    [0 .. time] |> List.map (getResultForTime time)

let getWinningCombinations ((time,distance): int*int) =
    let results = getResultsForTime time
    let filtered = results |> List.filter(fun result -> result > distance)
    filtered.Length

let product = List.fold (*) 1

let part1 text =
    let parts = text |> splitNewline |> Array.map parseNumbers
    List.zip (Array.head parts) (Array.last parts) // time*distance
    |> List.map getWinningCombinations
    |> product


let part2 text =
    0