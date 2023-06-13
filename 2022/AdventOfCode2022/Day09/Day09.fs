module Day09

open System

type Direction =
    | Up = 0
    | Down = 1
    | Left = 2
    | Right = 4

type Command = { Direction: Direction; Amount: int; }
type Position = (int*int)
type State = { Head: Position; Tail: Position}

let parseCommand (raw: string) = 
    let parts = raw.Split(" ")
    
    let direction =
        match parts.[0] with
        | "U" -> Direction.Up
        | "D" -> Direction.Down
        | "L" -> Direction.Left
        | "R" -> Direction.Right
        | _ -> failwith "Unknown direction"

    { Direction = direction; Amount = Int32.Parse parts.[1] }

let explodeCommand command =
    Array.create command.Amount command.Direction

let getNext current command =
    let headX, headY = current.Head
    match command with
    | Direction.Up -> { current with Head = (headX, headY + 1) }
    | Direction.Down -> { current with Head = (headX, headY - 1) }
    | Direction.Left -> { current with Head = (headX - 1, headY) }
    | Direction.Right -> { current with Head = (headX + 1, headY) }
    | _ -> failwith "Unknown direction"

let getNextTail next currentTail =
    let tailX, tailY = currentTail
    match next.Head with
        | (x,y) when x = tailX+2 && y = tailY -> { next with Tail = (tailX+1, tailY) } //east
        | (x,y) when x = tailX+2 && y = tailY-1 -> { next with Tail = (tailX+1, tailY-1) } //south-east
        | (x,y) when x = tailX+1 && y = tailY-2 -> { next with Tail = (tailX+1, tailY-1) } //south-east
        | (x,y) when x = tailX && y = tailY-2  -> { next with Tail = (tailX, tailY-1) } //south
        | (x,y) when x = tailX-2 && y = tailY-1  -> { next with Tail = (tailX-1, tailY-1) } //south-west
        | (x,y) when x = tailX-1 && y = tailY-2  -> { next with Tail = (tailX-1, tailY-1) } //south-west
        | (x,y) when x = tailX-2 && y = tailY  -> { next with Tail = (tailX-1, tailY) } //west
        | (x,y) when x = tailX-2 && y = tailY+1  -> { next with Tail = (tailX-1, tailY+1) } //north-west
        | (x,y) when x = tailX-1 && y = tailY+2  -> { next with Tail = (tailX-1, tailY+1) } //north-west
        | (x,y) when x = tailX && y = tailY+2  -> { next with Tail = (tailX, tailY+1) } //north
        | (x,y) when x = tailX+1 && y = tailY+2  -> { next with Tail = (tailX+1, tailY+1) } //north-east
        | (x,y) when x = tailX+2 && y = tailY+1  -> { next with Tail = (tailX+1, tailY+1) } //north-east
        | _ -> next

let getState (acc: State) (command: Direction) =
    let next = getNext acc command
    let result = getNextTail next acc.Tail

    result, result

let part1 (lines: string[]) =
    let commands = Array.map parseCommand lines |> Array.collect explodeCommand
    let start = { Head = (0,0); Tail = (0,0)}
    let result, _ = Array.mapFold getState start commands

    result |> Array.distinctBy(fun state -> state.Tail) |> Array.length
