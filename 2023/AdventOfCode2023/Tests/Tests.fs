module Tests

open Xunit
open System.IO

[<Theory>]
[<InlineData("Day01/Input/test.txt", 142)>]
[<InlineData("Day01/Input/prod.txt", 56108)>]
let ``Day01 - Part1`` (fileName, expected) =
    let text = File.ReadAllText(fileName)

    Assert.Equal(expected, (Day01.part1 text))

[<Theory>]
[<InlineData("Day01/Input/test2.txt", 281)>]
[<InlineData("Day01/Input/prod.txt", 55652)>]
let ``Day01 - Part2`` (fileName, expected) =
    let text = File.ReadAllText(fileName)

    Assert.Equal(expected, (Day01.part2 text))