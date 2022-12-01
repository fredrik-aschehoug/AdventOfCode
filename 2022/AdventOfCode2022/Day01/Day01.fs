module Day01

open System

let splitDoubleNewline (text: string) = text.Split("\r\n\r\n")
let splitNewline (text: string) = text.Split("\r\n")
let castToInt (lines: string[]) = Array.map Int32.Parse lines

let getElvesCalories (text: string) =
    splitDoubleNewline text
    |> Array.map splitNewline
    |> Array.map castToInt
    |> Array.map Array.sum

let part1 text =
    let elves = getElvesCalories text
    let topElf = Array.max elves
    topElf

let part2 text =
    let elves = getElvesCalories text
    let top3Sum = Array.sortDescending elves |> Array.take 3 |> Array.sum
    top3Sum

