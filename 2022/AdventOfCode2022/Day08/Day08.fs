module Day08

open System
open Common
open Microsoft.FSharp.Collections

let getMax (x: int, y: int) = Math.Max(x, y)

let parseLine (line: string) =
    line.ToCharArray()
    |> Array.map Casting.charToInt |> Array.toList

let rec getVisibleFromLeft (i: int, line: int list, top: int, result: int list) =
    if i = line.Length then result
    elif i = 0 then getVisibleFromLeft (i + 1, line, top, result @ [1])
    elif line.[i] > top then getVisibleFromLeft (i + 1, line, line.[i], result @ [1])
    else getVisibleFromLeft (i + 1, line, top, result @ [0])

let getVisibleInLine (line: int list) =
    let left = getVisibleFromLeft (0, line, line.Head, [])
    let right = getVisibleFromLeft (0, line |> List.rev, (List.rev line).Head, []) |> List.rev
    List.map2 (fun left right -> getMax(left, right)) left right

let rec getScoreFromLeft (heightIndex: int, i: int, line: int list, score: int) =
    let height = line.Item heightIndex
    if heightIndex = 0 then 0
    elif i = 0 then score + 1
    else
        if line.Item i >= height then score + 1
        else getScoreFromLeft (heightIndex, i - 1, line, score + 1)


let getScoreInLine (line: int list) = 
    let left = line |> List.indexed |> List.map(fun (index, tree) -> getScoreFromLeft (index, Math.Max(index - 1, 0), line, 0))
    let right = line |> List.rev |> List.indexed |> List.map(fun (index, tree) -> getScoreFromLeft (index, Math.Max(index - 1, 0), line |> List.rev, 0)) |> List.rev
    List.zip left right

let part1 (lines: string[]) =
    let forest = lines |> Array.toList |> List.map parseLine
    let visibleHorizontal = forest |> List.map getVisibleInLine
    let visibleVertical = forest |> Collections.transpose2dList |> List.map getVisibleInLine |> Collections.transpose2dList
    let visible = List.map2 (fun v h -> List.map2 (fun x y -> getMax(x, y)) h v) visibleHorizontal visibleVertical
    let visibleAmount = visible |> List.map(fun x -> List.sum x) |> List.sum

    visibleAmount

let part2 (lines: string[]) =
    let forest = lines |> Array.toList |> List.map parseLine
    let scoresHorizontal = forest |> List.map getScoreInLine |> List.concat
    let scoresVertical = forest |> Collections.transpose2dList |> List.map getScoreInLine |> Collections.transpose2dList |> List.concat
    List.map2 (fun (a, b) (c, d) -> a * b * c * d) scoresHorizontal scoresVertical |> List.max
