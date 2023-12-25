module Day08

open System
open Common.Parsing
open Common.Casting

type Direction =
    | Left
    | Right

type Node = { Name: string; Left: string; Right: string; }

let parseDirection c =
    match c with
    | 'L' -> Direction.Left
    | 'R' -> Direction.Right
    | _   -> failwith "Invalid direction"

let parseInstructions =
    toCharList >> List.map parseDirection

let strip (text: string) = text.Trim('(', ')')

let parseNode text =
    let parts = splitText " = " text
    let name = parts |> Array.head
    let lr = parts |> Array.last |> strip |> splitText ", "
    { Name = name; Left = (Array.head lr); Right = (Array.last lr)}

let getNextNode (nodes: Map<string, Node>) (currentNode: Node) direction =
    let nextNodeName =
        match direction with 
        | Direction.Left -> currentNode.Left
        | Direction.Right -> currentNode.Right
    nodes.Item nextNodeName

let rec traverseNetwork (nodes: Map<string, Node>) (instructions: Direction list) (originalInstructions: Direction list) steps (currentNode: Node) =
    match instructions with
    | [] ->
        let x::xs = originalInstructions
        let nextNode = getNextNode nodes currentNode x
        if currentNode.Name = "ZZZ" then steps else traverseNetwork nodes xs originalInstructions (steps + 1) nextNode
    | x::xs ->
        let nextNode = getNextNode nodes currentNode x
        if currentNode.Name = "ZZZ" then steps else traverseNetwork nodes xs originalInstructions (steps + 1) nextNode
    

let part1 text =
    let parts = splitDoubleNewline text
    let instructions = parts |> Array.head |> parseInstructions
    let nodes =
        parts
        |> Array.last
        |> splitNewline
        |> Array.toList
        |> List.map parseNode
        |> List.map (fun x -> x.Name, x)
        |> Map.ofList

    let startingNode = nodes.Item "AAA"
    traverseNetwork nodes instructions instructions 0 startingNode

let part2 text =
    0