module Day10

open System
open System.Collections.Generic

let cycles = [20; 60; 100; 140; 180; 220;]

type CommandType =
    | NoOp = 1
    | AddX = 2

type Command = { Type: CommandType; Argument: int Option}

type Result = { X: int; Clock: int }

let parseCommand (line: string) =
    let parts = Array.toList (line.Split(" "))

    match parts.Head with
    | "noop" -> { Type = CommandType.NoOp; Argument = None }
    | "addx" -> { Type = CommandType.AddX; Argument = Some(Int32.Parse parts.[1]) }

let getResult (command: Command) (previous: Result) =
    match command.Type with
    | CommandType.NoOp -> { X = previous.X; Clock = previous.Clock + 1}
    | CommandType.AddX -> { X = previous.X + command.Argument.Value; Clock = previous.Clock + 2}

let runCommands (commands: Command list) =
    let firstResult = getResult commands.Head { X = 1; Clock = 1 }
    let results = new List<Result>()
    results.Add(firstResult)
    
    for i = 1 to commands.Length - 1 do
        let prev = results.Item (i - 1)
        let current = commands.Item i
        let result = getResult current prev
        results.Add(result)
    
    results |> List.ofSeq

let rec getRegisterInCycle (cycle: int) (results: Result list) =
    let result = List.filter(fun result -> result.Clock = cycle) results
    if result.Length <> 0 then result.Head.X
    elif cycle < 0 then 1
    else getRegisterInCycle (cycle - 1) results

let getSum (results: Result list) =
    [for cycle in cycles -> (getRegisterInCycle cycle results) * cycle] |> List.sum

let getPixel (index: int, x: int) =
    let sprite = [(x-1)..(x+1)]
    if List.contains index sprite then "#" else "."

let getResults = Array.toList >> List.map parseCommand >> runCommands

let part1 = getResults >> getSum

let part2 lines =
    let results = getResults lines

    [for cycle in 1..240 -> getRegisterInCycle cycle results]
    |> List.chunkBySize 40
    |> List.map List.indexed
    |> List.map(fun line -> List.map getPixel line |> String.concat "") 
    |> List.iter(fun line -> printf $"{line}\n")
