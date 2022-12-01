module Tests

open System.IO
open Xunit
open Day01

[<Theory>]
[<InlineData("Input/input-day1-test.txt", 24000, 45000)>]
[<InlineData("Input/input-day1.txt", 68775, 202585)>]
let ``Day1`` (fileName, part1Result, part2Result) =
    let text = File.ReadAllText(fileName)

    let topElf = part1 text
    let top3Sum = part2 text

    Assert.Equal(part1Result, topElf)
    Assert.Equal(part2Result, top3Sum)

