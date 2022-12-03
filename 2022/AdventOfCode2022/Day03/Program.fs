open System.IO

[<EntryPoint>]
let main argv =
    let lines = File.ReadAllLines("Input/input-day3.txt")

    let prioritySum = Day03.part1 lines
    let badgeSum = Day03.part2 lines


    printf $"Part 1 = {prioritySum}\n"
    printf $"Part 2 = {badgeSum}\n"
    0 // return an integer exit code