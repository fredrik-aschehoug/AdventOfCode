module Day04

open System
open System.Linq

// ["1-3"; "2-3"] -> [[1; 2; 3]; [2; 3]]
let parseSections (pair: string[]) = 
    Array.map(fun (x: string) -> x.Split("-")) pair
    |> Array.map (Array.map Int32.Parse)
    |> Array.map(fun (x: int[]) -> [|x.[0] .. x.[1] |])

let isStrictOverlap (pair: int[][]) =
    pair.[0].All(fun x -> pair.[1].Contains(x)) || pair.[1].All(fun x -> pair.[0].Contains(x))

let isOverlap (pair: int[][]) =
    pair.[0].Any(fun x -> pair.[1].Contains(x))

let part1 =
    Array.map(fun (line: string) -> line.Split(","))
    >> Array.map parseSections
    >> Array.filter isStrictOverlap
    >> (fun x -> x.Count())

let part2 =
    Array.map(fun (line: string) -> line.Split(","))
    >> Array.map parseSections
    >> Array.filter isOverlap
    >> (fun x -> x.Count())