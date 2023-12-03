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

[<Theory>]
[<InlineData("Day02/Input/test.txt", 8, 2286)>]
[<InlineData("Day02/Input/prod.txt", 2810, 69110)>]
let ``Day02`` (fileName, expectedPart1, expectedPart2) =
    let text = File.ReadAllText(fileName)

    Assert.Equal(expectedPart1, (Day02.part1 text))
    Assert.Equal(expectedPart2, (Day02.part2 text))

[<Theory>]
[<InlineData("Day03/Input/test.txt", 4361, 0)>]
[<InlineData("Day03/Input/prod.txt", 560670, 0)>]
let ``Day03`` (fileName, expectedPart1, expectedPart2) =
    let text = File.ReadAllText(fileName)

    Assert.Equal(expectedPart1, (Day03.part1 text))
    Assert.Equal(expectedPart2, (Day03.part2 text))