open Day01

let readText filePath = System.IO.File.ReadAllText(filePath)

[<EntryPoint>]
let main argv =
    let text = readText "Input/input-day1.txt"

    let topElf = part1 text
    let top3Sum = part2 text

    printf $"Part 1 = {topElf}\n"
    printf $"Part 2 = {top3Sum}"
    
    0 // return an integer exit code