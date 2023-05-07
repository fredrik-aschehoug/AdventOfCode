module Day01

open System
open Common

let castToInt = Array.map Casting.stringToInt

let getElvesCalories =
    Text.splitDoubleNewline
    >> Array.map Text.splitNewline
    >> Array.map castToInt
    >> Array.map Array.sum

let part1 = getElvesCalories >> Array.max

let part2 = getElvesCalories >> Array.sortDescending >> Array.take 3 >> Array.sum

