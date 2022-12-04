module Day01

open System

let splitDoubleNewline (text: string) = text.Split("\r\n\r\n")
let splitNewline (text: string) = text.Split("\r\n")
let castToInt (lines: string[]) = Array.map Int32.Parse lines

let getElvesCalories =
    splitDoubleNewline
    >> Array.map splitNewline
    >> Array.map castToInt
    >> Array.map Array.sum

let part1 = getElvesCalories >> Array.max

let part2 = getElvesCalories >> Array.sortDescending >> Array.take 3 >> Array.sum

