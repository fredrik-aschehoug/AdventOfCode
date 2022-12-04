open System.IO


[<EntryPoint>]
let main argv =
    let lines = File.ReadAllLines("Input/input-day4.txt")
    
    let strictOverlappingPairs = Day04.part1 lines
    let overlappingPairs = Day04.part2 lines
    
    
    printf $"Part 1 = {strictOverlappingPairs}\n"
    printf $"Part 2 = {overlappingPairs}\n"
    0 // return an integer exit code