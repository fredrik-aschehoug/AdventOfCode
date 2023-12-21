module Day05.Part2

open System
open Day05.Common
open Common.Parsing

type Range = { Start: Int64; End: Int64; }

let getSeedRange (seeds: int64 list) =
    let start = List.head seeds
    let length = List.last seeds
    { Start = start; End = start + length - 1L }

let parseSeedRanges text =
    let numbers = parseSeeds text
    List.chunkBySize 2 numbers |> List.map getSeedRange

let getOffset (map: MapItem) = map.DestinationStart - map.SourceStart

let mapRange (map: MapItem option) (range: Range) =
    if map.IsNone then [] else
    let offset = getOffset map.Value
    [{ Start = range.Start + offset; End = range.End + offset }]
   
let calculateWhenLower (map: MapItem) (range: Range) =
    let offset = getOffset map
    let last = map.SourceStart + map.Length - 1L
    let first = { Start = range.Start + offset; End = last + offset }
    let second = { range with Start = last + 1L}
    [first; second]

let calculateWhenHigher (map: MapItem) (range: Range) =
    let offset = getOffset map
    let start = map.SourceStart
    let first = { range with End = start - 1L }
    let second = { Start = start + offset; End = range.End + offset}
    [first; second]

let mapPartialRange (map: MapItem option) (range: Range) =
    if map.IsNone then [] else
    let isLower = range.End > map.Value.SourceStart + map.Value.Length - 1L
    if isLower then calculateWhenLower map.Value range else calculateWhenHigher map.Value range

let isPartialMatch range map =
    let sourceEnd = map.SourceStart + map.Length - 1L
    let startInRange = (range.Start >= map.SourceStart && range.Start <= sourceEnd)
    let endInRange = (range.End >= map.SourceStart && range.End <= sourceEnd)
    startInRange || endInRange

let calculateRange (map: Map) (range: Range) =
    let applicableMap = map.Items |> List.filter(fun m -> range.Start >= m.SourceStart && range.End <= (m.SourceStart + m.Length - 1L)) |> List.tryHead
    let partialMatch = map.Items |> List.filter (isPartialMatch range) |> List.tryHead
    let results = List.concat [(mapRange applicableMap range); if applicableMap.IsNone then (mapPartialRange partialMatch range)]
    if results.IsEmpty then [range] else results

let rec getNextState (map: Map) (result: Range list) (queue: Range list) =
    match queue with
    | [] -> result
    | x :: xs ->
        let calculated = calculateRange map x 
        getNextState map (calculated @ result) xs

let folder (acc: Range list) (map: Map) =
    let res = acc |> List.map(fun range -> getNextState map [] [range]) |> List.concat
    res

let main text =
    let parts = splitDoubleNewline text |> Array.toList
    let head :: rest = parts
    let seeds = parseSeedRanges head
    let maps = rest |>  List.map parseMap
    List.fold folder seeds maps
    |> List.map(fun range -> range.Start)
    |> List.filter(fun x -> x > 0)
    |> List.min
