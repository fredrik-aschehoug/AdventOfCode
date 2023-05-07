module Day03

let getDuplicates (rucksack: char[]) =
    let mid = rucksack.Length / 2
    let left, right = rucksack |> Array.splitAt mid
    Set.intersect (Set.ofArray left) (Set.ofArray right) |> Set.toArray

let alphaLookup =
    let alfabet = Seq.concat [['a' .. 'z']; ['A' .. 'Z']]
    let scores = [1 .. 52]
    Map (Seq.zip alfabet scores)

let getScore c = alphaLookup.[c]

let intersectGroup (group: char[][]) =
    Set.intersect (Set.ofArray group.[0]) (Set.ofArray group.[1])
    |> Set.intersect (Set.ofArray group.[2])
    |> Set.toArray

let part1 (rucksacks: string[]) =
    Array.map Seq.toArray rucksacks
    |> Array.map getDuplicates
    |> Array.concat
    |> Array.map getScore
    |> Array.sum

let part2 (rucksacks: string[]) =
    Array.map Seq.toArray rucksacks
    |> Array.chunkBySize 3
    |> Array.map intersectGroup
    |> Array.concat
    |> Array.map getScore
    |> Array.sum
