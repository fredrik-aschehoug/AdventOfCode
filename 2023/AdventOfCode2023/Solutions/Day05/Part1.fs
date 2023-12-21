module Day05.Part1

open Common.Parsing
open Day05.Common


let mapNumber (map: MapItem) (number: int64) =
    let diff = number - map.SourceStart
    map.DestinationStart + diff

let isInRange (number: int64) (start: int64) (length: int64) =
    number >= start && number < (start + length)
    
let getNextState (map: Map) (number: int64) =
    let applicableMap = map.Items |> List.filter(fun m -> isInRange number m.SourceStart m.Length)
    match applicableMap with
    | [] -> number
    | [ item ] -> mapNumber item number
    | _ -> failwith("More than 1 applicable map, wtf!")

let folder (acc: int64 list) (map: Map) =
    acc |> List.map (getNextState map)

let main (text: string) =
    let parts = splitDoubleNewline text |> Array.toList
    let head :: rest = parts
    let seeds = parseSeeds head
    let maps = rest |>  List.map parseMap
    let locations = List.fold folder seeds maps
    List.min locations
