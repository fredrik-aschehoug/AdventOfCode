module Day05

open System
open Common.Parsing

type MapItem = {
    SourceStart: Int64;
    DestinationStart: Int64;
    Length: Int64;
}

type Map = { Items: MapItem list; }

let parseSeeds =
    splitText ": "
    >> Array.last
    >> splitText " "
    >> Array.map Int64.Parse
    >> Array.toList

let parseMapItem (map: string) =
    let parts = splitText " " map
    {
        DestinationStart = Int64.Parse parts.[0]
        SourceStart = Int64.Parse parts.[1]
        Length = Int64.Parse parts.[2]
    }

let parseMap (map: string) =
    let maps = map |> splitNewline |> Array.tail |> Array.map parseMapItem |> Array.toList
    { Items = maps }

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

let part1 (text: string) =
    let parts = splitDoubleNewline text |> Array.toList
    let head :: rest = parts
    let seeds = parseSeeds head
    let maps = rest |>  List.map parseMap
    let locations = List.fold folder seeds maps
    List.min locations

let part2 text =
    0
    