module Day02

let linesToTuples =
    Array.map(fun (x: string) -> x.Split(" "))
    >> Array.map(fun (x: string[]) -> (x.[0], x.[1]))

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

let transformMove (move: string*string) =
    let opponent, you = move
    match opponent with
    | "A" when you = "X" -> (opponent, "Z")
    | "A" when you = "Y" -> (opponent, "X")
    | "A" when you = "Z" -> (opponent, "Y")
    | "B" when you = "X" -> (opponent, "X")
    | "B" when you = "Y" -> (opponent, "Y")
    | "B" when you = "Z" -> (opponent, "Z")
    | "C" when you = "X" -> (opponent, "Y")
    | "C" when you = "Y" -> (opponent, "Z")
    | "C" when you = "Z" -> (opponent, "X")

let part1 =
    linesToTuples
    >> Array.map getMoveScore
    >> Array.sum

let part2 =
    linesToTuples
    >> Array.map transformMove
    >> Array.map getMoveScore
    >> Array.sum