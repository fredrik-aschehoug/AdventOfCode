﻿module Day05

open System
open System.Linq
open System.Text.RegularExpressions
open System.Collections.Generic

let rec getStackPosition (stack: int) =
    if stack = 0 then 1
    else 4 + getStackPosition (stack - 1)

let parseLine (line: string[]) stacksCount = 
    let stacks = [|0 .. stacksCount - 1|]
    let mutable positions: string list = []
    for stack in stacks do
        let position = getStackPosition stack
        let value = line.ElementAtOrDefault(position)
        positions <- value :: positions

    positions |> List.rev

let parseLines (lines: string[]) stacksCount =
    Array.map(fun (x: string) -> x.ToArray()) lines
    |> Array.map (Array.map(fun x -> x.ToString()))
    |> Array.map(fun line -> parseLine line stacksCount)

let parseStacks (text: string) =
    let lines = text.Split("\r\n").SkipLast(1).ToArray() |> Array.rev
    let rx = Regex(@"\w", RegexOptions.Compiled)
    
    let stacksCount = rx.Matches(lines.First()).Count
    let stacks = [|for stack in [1 .. stacksCount] do new Stack<string>()|]
    let parsedLines = parseLines lines stacksCount
    for line in parsedLines do
        for i = 0 to parsedLines.Length do
            let element = line.ElementAtOrDefault(i)
            if (element <> " " && element <> null) then stacks.[i].Push(element)
    stacks

let parseInstruction (instruction: string) =
    let instructions = instruction.Split(" ")
    let amount = Int32.Parse(instructions.[1])
    let source = Int32.Parse(instructions.[3])
    let destination = Int32.Parse(instructions.[5])
    (amount, source, destination)

let parseInstructions =
    Array.map parseInstruction
    
let getResult (stacks: Stack<string>[]) = String.Join("", [for stack in stacks do stack.Peek()])

let part1 (text: string) =
    let [|stacksText; instructionsText|] = text.Split("\r\n\r\n")
    let stacks = parseStacks stacksText

    let instructions = parseInstructions (instructionsText.Split("\r\n"))
    
    for instruction in instructions do
        let (amount, source, destination) = instruction
        for i = 0 to amount - 1 do
            let item = stacks.[source - 1].Pop()
            stacks.[destination - 1].Push(item)
    
    getResult stacks

let part2 (text: string) =
    let [|stacksText; instructionsText|] = text.Split("\r\n\r\n")
    let stacks = parseStacks stacksText

    let instructions = parseInstructions (instructionsText.Split("\r\n"))

    for instruction in instructions do
        let (amount, source, destination) = instruction
        let tempStack = new Stack<string>()
        for i = 0 to amount - 1 do
            let item = stacks.[source - 1].Pop()
            tempStack.Push(item)
        while tempStack.Count > 0 do
            stacks.[destination - 1].Push(tempStack.Pop())

    getResult stacks
