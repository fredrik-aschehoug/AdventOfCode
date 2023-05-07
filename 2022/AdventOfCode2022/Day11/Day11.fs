module Day11

open System
open System.Collections
open System.Text.RegularExpressions
open Common
open Common.SystemExtensions

type Test = { DivisibleBy: int; IfTrue: int; IfFalse: int; }
type Monkey = { Items: Generic.Queue<float>; Operation: string; Test: Test; Inspections: int64; }

let parseMonkey raw =
    let lines = Text.splitNewline raw
    {
        Items = lines.[1].Remove(0, 18).Split(", ") |> Array.map Casting.stringToFloat |> Collections.toQueue;
        Operation = lines.[2].Remove(0, 23);
        Test = {
            DivisibleBy = lines.[3].Remove(0, 21).ToInt;
            IfTrue = lines.[4].Remove(0, 29).ToInt;
            IfFalse = lines.[5].Remove(0, 30).ToInt;
        };
        Inspections = 0;
    }

let getNumber (operation: string) (fallback: float) =
    let rxMatch = Regex(@"\d+", RegexOptions.Compiled).Match(operation)
    if rxMatch.Success then rxMatch.Value.ToFloat else fallback

let getWorryLevel (item: float) (operation: string) =
    let op = operation.[0]
    let number = getNumber operation item
    if op = '+' then item + number
    else item * number

let inspect (item: float) (operation: string) =
    let worryLevel = getWorryLevel item operation
    Math.Floor((worryLevel |> float) / (3 |> float))

let inspectV2 x (item: float) (operation: string) =
    let worryLevel = getWorryLevel item operation
    worryLevel % x
    
let doRound (monkeys: Monkey[]) (inspector: (float -> string -> float)) =
    for (i, monkey) in Array.indexed monkeys do
        monkeys.[i] <- { monkey with Inspections = monkey.Inspections + int64 monkey.Items.Count}
        while monkey.Items.Count > 0 do
            let item = inspector (monkey.Items.Dequeue()) monkey.Operation
            if item % (monkey.Test.DivisibleBy |> float) = 0 then
                // throw item to true
                monkeys.[monkey.Test.IfTrue].Items.Enqueue(item)
            else
                // throw item to false
                monkeys.[monkey.Test.IfFalse].Items.Enqueue(item)

let getMonkeyBusiness =
    Array.map(fun monkey -> monkey.Inspections)
    >> Array.sortDescending
    >> Array.take 2
    >> Array.fold (*) (int64 1)

let part1 (text: string) =
    let monkeys = text |> Text.splitDoubleNewline |> Array.map parseMonkey
    
    for round = 1 to 20 do
        doRound monkeys inspect

    getMonkeyBusiness monkeys

let part2 (text: string) =
    let monkeys = text |> Text.splitDoubleNewline |> Array.map parseMonkey
    
    let x = monkeys |> Array.map(fun monkey -> monkey.Test.DivisibleBy) |> Array.fold (*) 1
    let inspector = inspectV2 x

    for round = 1 to 10000 do
        doRound monkeys inspector

    getMonkeyBusiness monkeys