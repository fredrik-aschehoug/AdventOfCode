module Day08

open System
open Common
open Microsoft.FSharp.Collections

let getMax (x: int) (y: int) = Math.Max(x, y)

let parseLine (line: string) =
    line.ToCharArray()
    |> Array.map Casting.charToInt |> Array.toList

let rec getVisibleFromLeft i (line: int list) top result  =
    if i = line.Length then result
    elif i = 0 then getVisibleFromLeft (i + 1) line top (result @ [1])
    elif line.[i] > top then getVisibleFromLeft (i + 1) line line.[i] (result @ [1])
    else getVisibleFromLeft (i + 1) line top (result @ [0])

let getVisibleInLine (line: int list) =
    let visibleFn line = getVisibleFromLeft 0 line line.Head []
    let left = visibleFn line
    let right = visibleFn (List.rev line) |> List.rev
    List.map2 getMax left right

let rec getScoreFromLeft heightIndex i score (line: int list)  =
    let height = line.Item heightIndex
    match heightIndex with
    | 0 -> 0
    | _ when i = 0 ->  score + 1
    | _ when line.Item i >= height -> score + 1
    | _ -> getScoreFromLeft heightIndex (i - 1) (score + 1) line 

let getScoreInLine (line: int list) =
    let scoreFn index line = getScoreFromLeft index (Math.Max(index - 1, 0)) 0 line
    let left = 
        line |> List.indexed
        |> List.map(fun (index, tree) -> scoreFn index line)
    let right =
        line |> List.rev
        |> List.indexed
        |> List.map(fun (index, tree) -> scoreFn index (List.rev line))
        |> List.rev
    List.zip left right

let getForest = Array.toList >> List.map parseLine

let part1 lines =
    let forest = getForest lines
    let visibleHorizontal = forest |> List.map getVisibleInLine
    let visibleVertical =
        forest |> Collections.transpose2dList
        |> List.map getVisibleInLine
        |> Collections.transpose2dList

    let visible = List.map2 (fun v h -> List.map2 getMax h v) visibleHorizontal visibleVertical
    let visibleAmount = visible |> List.map List.sum |> List.sum

    visibleAmount

let part2 lines =
    let forest = getForest lines
    let scoresHorizontal = forest |> List.map getScoreInLine |> List.concat
    let scoresVertical =
        forest |> Collections.transpose2dList
        |> List.map getScoreInLine
        |> Collections.transpose2dList
        |> List.concat

    List.map2 (fun (a, b) (c, d) -> a * b * c * d) scoresHorizontal scoresVertical |> List.max
