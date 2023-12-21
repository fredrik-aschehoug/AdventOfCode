module Day06

open System
open Common.Parsing
open System.Text.RegularExpressions

let numberRx = Regex(@"\d+", RegexOptions.Compiled)

let parseNumbers text =
    [for number in numberRx.Matches(text) do yield number.Value ]
    |> List.map Int32.Parse

let getResultForTime (time: int64) (pressTime: int64) =
    let speed = pressTime
    let timeLeft = time - pressTime
    speed * timeLeft

let getResultsForTime (time: int64) =
    [0L .. time] |> List.map (getResultForTime time)

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

let parseNumber text =
    [for number in numberRx.Matches(text) do yield number.Value ]
    |> String.concat ""
    |> Int64.Parse

let isWinning (time: int64) (distanceToBeat: int64) (pressTime: int64) =
    let result = getResultForTime time pressTime
    result > distanceToBeat

let getWinningCombinationsV2 (time: int64) (distance: int64) =
    let choises = [0L .. time]
    let lowest = choises |> List.findIndex (isWinning time distance)
    let highest = choises |> List.findIndexBack (isWinning time distance)
    highest - lowest + 1
    
let part2 text =
    let parts = text |> splitNewline |> Array.map parseNumber
    getWinningCombinationsV2 (Array.head parts) (Array.last parts)
