module Day01

open Common.Parsing
open Common.Casting

let getLocationId text part =
    let parts = splitText "   " text
    stringToInt parts[part]

let getFirstId text = getLocationId text 0
let getSecondId text = getLocationId text 1

let getDistance (x: int, y: int) =
    abs (x - y)

let getSimilarity number rightList =
    let apperances = rightList |> Array.filter (fun num -> num = number) |> Array.length
    apperances * number

let part1 text =
    let lines = text |> splitNewline
    let first = lines |> Array.map getFirstId |> Array.sort
    let second = lines |> Array.map getSecondId |> Array.sort
    Array.zip first second |> Array.map getDistance |> Array.sum

let part2 text =
    let lines = text |> splitNewline
    let first = lines |> Array.map getFirstId
    let second = lines |> Array.map getSecondId
    first |> Array.map (fun number -> getSimilarity number second) |> Array.sum
