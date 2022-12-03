module Day03

open System.Collections.Generic

let getDuplicates (rucksack: char[]) =
    let mid = rucksack.Length / 2
    let left, right = rucksack |> Array.splitAt mid
    Set.intersect (Set.ofArray left) (Set.ofArray right) |> Set.toArray

let getAlfaDict =
    let alfabet = Seq.concat [['a' .. 'z']; ['A' .. 'Z']]
    let scores = [1 .. 52]
    let alfaScores = Seq.zip alfabet scores
    let alfaToNum = Dictionary<char, int>()
    for (letter, score) in alfaScores do
        alfaToNum.Add(letter, score)
    alfaToNum

let intersectGroup (group: char[][]) =
    Set.intersect (Set.ofArray group.[0]) (Set.ofArray group.[1])
    |> Set.intersect (Set.ofArray group.[2])
    |> Set.toArray

let part1 (rucksacks: string[]) =
    let alphaLookup = getAlfaDict
    Array.map Seq.toArray rucksacks
    |> Array.map getDuplicates
    |> Array.concat
    |> Array.map(fun c -> alphaLookup.[c]) //convert alpha to num
    |> Array.sum

let part2 (rucksacks: string[]) =
    let alphaLookup = getAlfaDict
    Array.map Seq.toArray rucksacks
    |> Array.chunkBySize 3
    |> Array.map intersectGroup
    |> Array.concat
    |> Array.map(fun c -> alphaLookup.[c]) //convert alpha to num
    |> Array.sum
