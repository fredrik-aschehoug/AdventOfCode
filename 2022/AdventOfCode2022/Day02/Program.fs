open System.IO


[<EntryPoint>]
let main argv =
    let lines = File.ReadAllLines("Input/input-day2.txt")
    
    let score = Day02.part1 lines
    let correctScore = Day02.part2 lines

    printf $"Part 1 = {score}\n"
    printf $"Part 2 = {correctScore}"
    0 // return an integer exit code