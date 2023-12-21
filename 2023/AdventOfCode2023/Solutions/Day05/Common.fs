module Day05.Common

open System
open Common.Parsing

type MapItem = {
    SourceStart: Int64;
    DestinationStart: Int64;
    Length: Int64;
}

type Map = { Items: MapItem list; }

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

let parseSeeds =
    splitText ": "
    >> Array.last
    >> splitText " "
    >> Array.map Int64.Parse
    >> Array.toList