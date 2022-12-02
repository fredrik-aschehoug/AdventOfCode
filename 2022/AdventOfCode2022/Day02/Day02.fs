module Day02

let getMoveScore (move: string*string) =
    let opponent, you = move
    match opponent with
    | "A" when you = "X" -> 1 + 3
    | "A" when you = "Y" -> 2 + 6
    | "A" when you = "Z" -> 3 + 0
    | "B" when you = "X" -> 1 + 0
    | "B" when you = "Y" -> 2 + 3
    | "B" when you = "Z" -> 3 + 6
    | "C" when you = "X" -> 1 + 6
    | "C" when you = "Y" -> 2 + 0
    | "C" when you = "Z" -> 3 + 3

let getAllScores (lines: string[]) =
    Array.map(fun (x: string) -> x.Split(" ")) lines
    |> Array.map(fun (x: string[]) -> (x.[0], x.[1]))
    |> Array.map getMoveScore

let part1 (lines: string[]) =
    getAllScores lines |> Array.sum
