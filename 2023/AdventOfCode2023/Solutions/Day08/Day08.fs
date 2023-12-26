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
   
let rec traverseNetwork comparer (nodes: Map<string, Node>) (instructions: Direction list) (originalInstructions: Direction list) steps (currentNode: Node) =
    match instructions with
    | [] ->
        let x::xs = originalInstructions
        let nextNode = getNextNode nodes currentNode x
        if comparer currentNode.Name then steps else traverseNetwork comparer nodes xs originalInstructions (steps + 1) nextNode
    | x::xs ->
        let nextNode = getNextNode nodes currentNode x
        if comparer currentNode.Name then steps else traverseNetwork comparer nodes xs originalInstructions (steps + 1) nextNode

let parseNodes =
    splitNewline
    >> Array.toList
    >> List.map parseNode
    >> List.map (fun x -> x.Name, x)
    >> Map.ofList

let part1Comparer name = name = "ZZZ"

let part1 text =
    let parts = splitDoubleNewline text
    let instructions = parts |> Array.head |> parseInstructions
    let nodes = parts |> Array.last |> parseNodes
        
    let startingNode = nodes.Item "AAA"
    traverseNetwork part1Comparer nodes instructions instructions 0 startingNode


let rec gcd (x: int64) (y: int64) =
    if y = 0 then x else gcd y (x % y)

let lcmFolder acc cur = acc * cur / (gcd acc cur)
   
let part2Comparer (name: string) = name.EndsWith('Z')

let part2 text =
    let parts = splitDoubleNewline text
    let instructions = parts |> Array.head |> parseInstructions
    let nodes = parts |> Array.last |> parseNodes
    let startingNodes = nodes |> Map.filter (fun n s -> n.EndsWith('A')) |> Map.toList |> List.map (fun (n,s) -> s)
    let steps = startingNodes |> List.map (traverseNetwork part2Comparer nodes instructions instructions 0)
    let initialState = (int64 (List.head steps))
    
    steps |> List.map int64 |> List.fold lcmFolder initialState