module Day04

open System

// ["1-3"; "2-3"] -> [[1; 2; 3]; [2; 3]]
let parseSections (pair: string[]) = 
    Array.map(fun (x: string) -> x.Split("-")) pair
    |> Array.map (Array.map Int32.Parse)
    |> Array.map(fun (x: int[]) -> [|x.[0] .. x.[1] |])

let isStrictOverlap (pair: int[][]) =
    Array.forall (fun x -> Array.contains x pair.[1]) pair.[0] ||
    Array.forall (fun x -> Array.contains x pair.[0]) pair.[1]

let isOverlap (pair: int[][]) =
    Array.exists (fun x -> Array.contains x pair.[1]) pair.[0]

let part1 =
    Array.map(fun (line: string) -> line.Split(","))
    >> Array.map parseSections
    >> Array.filter isStrictOverlap
    >> (fun x -> x.Length)

let part2 =
    Array.map(fun (line: string) -> line.Split(","))
    >> Array.map parseSections
    >> Array.filter isOverlap
    >> (fun x -> x.Length)