namespace IntegrationTests


open Xunit
open System.IO

type Tests() =
    [<Theory>]
    [<InlineData("Day01/Input/test.txt", 11)>]
    [<InlineData("Day01/Input/prod.txt", 2375403)>]
    let ``Day01 - Part1`` (fileName, expected) =
        let text = File.ReadAllText(fileName)

        Assert.Equal(expected, (Day01.part1 text))

    [<Theory>]
    [<InlineData("Day01/Input/test.txt", 31)>]
    [<InlineData("Day01/Input/prod.txt", 23082277)>]
    let ``Day01 - Part2`` (fileName, expected) =
        let text = File.ReadAllText(fileName)

        Assert.Equal(expected, (Day01.part2 text))

    [<Theory>]
    [<InlineData("Day02/Input/test.txt", 2)>]
    [<InlineData("Day02/Input/prod.txt", 299)>]
    let ``Day02 - Part1`` (fileName, expected) =
        let text = File.ReadAllText(fileName)

        Assert.Equal(expected, (Day02.part1 text))

    [<Theory>]
    [<InlineData("Day02/Input/test.txt", 4)>]
    [<InlineData("Day02/Input/prod.txt", 364)>]
    let ``Day02 - Part2`` (fileName, expected) =
        let text = File.ReadAllText(fileName)

        Assert.Equal(expected, (Day02.part2 text))