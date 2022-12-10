module Day08

open System
open System.Linq
open Common

let getMax (x: int, y: int) = Math.Max(x, y)

let parseLine (line: string) =
    line.ToCharArray()
    |> Array.map Casting.charToInt |> Array.toList

let rec GetVisibleFromLeft (i: int, line: int list, top: int, result: int list) =
    if i = line.Length then result
    elif i = 0 then GetVisibleFromLeft (i + 1, line, top, result @ [1])
    elif line.[i] > top then GetVisibleFromLeft (i + 1, line, line.[i], result @ [1])
    else GetVisibleFromLeft (i + 1, line, top, result @ [0])

let rec GetVisibleFromRight (i: int, line: int list, top: int, result: int list) =
    if i = line.Length then result
    elif i = 0 then GetVisibleFromLeft (i + 1, line, top, result @ [1])
    elif line.[i] > top then GetVisibleFromLeft (i + 1, line, line.[i], result @ [1])
    else GetVisibleFromLeft (i + 1, line, top, result @ [0])

let getVisibleInLine (line: int list) =
    let left = GetVisibleFromLeft (0, line, line.First(), [])
    let right = GetVisibleFromLeft (0, line |> List.rev, line.Last(), []) |> List.rev
    List.map2 (fun left right -> getMax(left, right)) left right

let part1 (lines: string[]) =
    let forest = lines |> Array.toList |> List.map parseLine
    let visibleHorizontal = forest |> List.map getVisibleInLine
    let visibleVertical = forest |> Collections.transpose2dList |> List.map getVisibleInLine |> Collections.transpose2dList
    let visible = List.map2 (fun v h -> List.map2 (fun x y -> getMax(x, y)) h v) visibleHorizontal visibleVertical
    let visibleAmount = visible |> List.map(fun x -> List.sum x) |> List.sum

    visibleAmount