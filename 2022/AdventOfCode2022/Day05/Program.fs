open System.IO

[<EntryPoint>]
let main argv =
    let text = File.ReadAllText("Input/input-day5.txt")
    
    let crates9000 = Day05.part1 text
    let crates9001 = Day05.part2 text
    printf $"Part 1 = {crates9000}\n"
    printf $"Part 1 = {crates9001}\n"
    0 // return an integer exit code