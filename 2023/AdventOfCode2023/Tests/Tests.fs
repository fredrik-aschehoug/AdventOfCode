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
[<InlineData("Day03/Input/test.txt", 4361, 467835)>]
[<InlineData("Day03/Input/prod.txt", 560670, 91622824)>]
let ``Day03`` (fileName, expectedPart1, expectedPart2) =
    let text = File.ReadAllText(fileName)

    Assert.Equal(expectedPart1, (Day03.part1 text))
    Assert.Equal(expectedPart2, (Day03.part2 text))

[<Theory>]
[<InlineData("Day04/Input/test.txt", 13, 30)>]
[<InlineData("Day04/Input/prod.txt", 26914, 13080971)>]
let ``Day04`` (fileName, expectedPart1, expectedPart2) =
    let text = File.ReadAllText(fileName)

    Assert.Equal(expectedPart1, (Day04.part1 text))
    Assert.Equal(expectedPart2, (Day04.part2 text))

[<Theory>]
[<InlineData("Day05/Input/test.txt", 35, 46)>]
[<InlineData("Day05/Input/prod.txt", 227653707, 78775051)>]
let ``Day05`` (fileName, expectedPart1, expectedPart2) =
    let text = File.ReadAllText(fileName)

    Assert.Equal(expectedPart1, (Day05.Part1.main text))
    Assert.Equal(expectedPart2, (Day05.Part2.main text))