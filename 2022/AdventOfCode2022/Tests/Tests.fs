module Tests

open System.IO
open Xunit

[<Theory>]
[<InlineData("Input/input-day1-test.txt", 24000, 45000)>]
[<InlineData("Input/input-day1.txt", 68775, 202585)>]
let ``Day1`` (fileName, part1Result, part2Result) =
    let text = File.ReadAllText(fileName)

    let topElf = Day01.part1 text
    let top3Sum = Day01.part2 text

    Assert.Equal(part1Result, topElf)
    Assert.Equal(part2Result, top3Sum)

[<Theory>]
[<InlineData("Input/input-day2-test.txt", 15, 12)>]
[<InlineData("Input/input-day2.txt", 11386, 13600)>]
let ``Day2`` (fileName, part1Result: int, part2Result) =
    let lines = File.ReadAllLines(fileName)

    let score = Day02.part1 lines
    let correctScore = Day02.part2 lines

    Assert.Equal(part1Result, score)
    Assert.Equal(part2Result, correctScore)
