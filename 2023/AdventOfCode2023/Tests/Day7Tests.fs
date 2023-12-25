namespace UnitTests

open Xunit
open Common.Casting


type Day7Tests() =
    [<Theory>]
    [<InlineData("11111", true)>]
    [<InlineData("QQQQQ", true)>]
    [<InlineData("32T3K", false)>]
    [<InlineData("12345", false)>]
    [<InlineData("11112", false)>]
    [<InlineData("21111", false)>]
    let ``isFiveOfAKind`` (text: string, expected: bool) =

        let actual = Day07.Part1.isFiveOfAKind (toCharList text)

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11110", true)>]
    [<InlineData("01111", true)>]
    [<InlineData("11011", true)>]
    [<InlineData("QQQQQ", false)>]
    [<InlineData("32T3K", false)>]
    [<InlineData("12345", false)>]
    [<InlineData("11122", false)>]
    [<InlineData("21121", false)>]
    let ``isFourOfAKind`` (text: string, expected: bool) =

        let actual = Day07.Part1.isFourOfAKind (toCharList text)

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11100", true)>]
    [<InlineData("01110", true)>]
    [<InlineData("01111", false)>]
    [<InlineData("12122", true)>]
    [<InlineData("QQQQQ", false)>]
    [<InlineData("12345", false)>]
    [<InlineData("11123", false)>]
    [<InlineData("21121", true)>]
    let ``isFullHouse`` (text: string, expected: bool) =

        let actual = Day07.Part1.isFullHouse (toCharList text)

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11100", true)>]
    [<InlineData("01110", true)>]
    [<InlineData("01111", false)>]
    [<InlineData("12122", true)>]
    [<InlineData("2Q1QQ", true)>]
    [<InlineData("12345", false)>]
    [<InlineData("11123", true)>]
    [<InlineData("21121", true)>]
    [<InlineData("AAAAA", false)>]
    let ``isThreeOfAKind`` (text: string, expected: bool) =

        let actual = Day07.Part1.isThreeOfAKind (toCharList text)

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11200", true)>]
    [<InlineData("011A0", true)>]
    [<InlineData("12123", true)>]
    [<InlineData("12122", false)>]
    [<InlineData("2Q1QQ", false)>]
    [<InlineData("12345", false)>]
    [<InlineData("11123", false)>]
    [<InlineData("21121", false)>]
    [<InlineData("AAAAA", false)>]
    let ``isTwoPair`` (text: string, expected: bool) =

        let actual = Day07.Part1.isTwoPair (toCharList text)

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11111", true)>]
    [<InlineData("QQJQQ", true)>]
    [<InlineData("JJ111", true)>]
    [<InlineData("QQQQQ", true)>]
    [<InlineData("QQQQJ", true)>]
    [<InlineData("QQQJJ", true)>]
    [<InlineData("QQJJJ", true)>]
    [<InlineData("QJJJJ", true)>]
    [<InlineData("JJJJJ", true)>]
    [<InlineData("JJQJJ", true)>]
    [<InlineData("32T3K", false)>]
    [<InlineData("12345", false)>]
    [<InlineData("11112", false)>]
    [<InlineData("21111", false)>]
    [<InlineData("12222", false)>]
    [<InlineData("1222J", false)>]
    [<InlineData("122JJ", false)>]
    [<InlineData("12JJJ", false)>]
    let ``isFiveOfAKind - Part 2`` (text: string, expected: bool) =

        let actual = Day07.Part2.isFiveOfAKind (toCharList text)

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11110", true)>]
    [<InlineData("01111", true)>]
    [<InlineData("11011", true)>]
    [<InlineData("111J0", true)>]
    [<InlineData("011J1", true)>]
    [<InlineData("110JJ", true)>]
    [<InlineData("T55J5", true)>]
    [<InlineData("KTJJT", true)>]
    [<InlineData("QQQJA", true)>]
    [<InlineData("QQQQQ", false)>]
    [<InlineData("32T3K", false)>]
    [<InlineData("12345", false)>]
    [<InlineData("11122", false)>]
    [<InlineData("21121", false)>]
    [<InlineData("12222", true)>]
    [<InlineData("1222J", true)>]
    [<InlineData("122JJ", true)>]
    [<InlineData("12JJJ", true)>]
    [<InlineData("11222", false)>]
    [<InlineData("1122J", false)>]
    let ``isFourOfAKind - Part 2`` (text: string, expected: bool) =
        let jokers = toCharList text|> List.filter (fun l -> l = 'J') |> List.length
        let actual = Day07.Part2.isFourOfAKind (toCharList text) jokers

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11100", true)>]
    [<InlineData("01110", true)>]
    [<InlineData("21121", true)>]
    [<InlineData("12122", true)>]
    [<InlineData("21J21", true)>]
    [<InlineData("2233J", true)>]
    [<InlineData("21JJ1", true)>]
    [<InlineData("21JJJ", true)>]
    [<InlineData("01111", false)>]
    [<InlineData("QQQQQ", false)>]
    [<InlineData("12345", false)>]
    [<InlineData("11123", false)>]
    [<InlineData("11222", true)>]
    [<InlineData("1122J", true)>]
    [<InlineData("12333", false)>]
    [<InlineData("1233J", false)>]
    [<InlineData("123JJ", false)>]
    let ``isFullHouse - Part 2`` (text: string, expected: bool) =
        let jokers = toCharList text|> List.filter (fun l -> l = 'J') |> List.length
        let actual = Day07.Part2.isFullHouse (toCharList text) jokers

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11100", true)>]
    [<InlineData("01110", true)>]
    [<InlineData("01111", false)>]
    [<InlineData("12122", true)>]
    [<InlineData("2Q1QQ", true)>]
    [<InlineData("12345", false)>]
    [<InlineData("11123", true)>]
    [<InlineData("21121", true)>]
    [<InlineData("2110J", true)>]
    [<InlineData("21J0J", true)>]
    [<InlineData("AAAAA", false)>]
    [<InlineData("12333", true)>]
    [<InlineData("1233J", true)>]
    [<InlineData("123JJ", true)>]
    let ``isThreeOfAKind - Part 2`` (text: string, expected: bool) =
        let jokers = toCharList text|> List.filter (fun l -> l = 'J') |> List.length
        let actual = Day07.Part2.isThreeOfAKind (toCharList text) jokers

        Assert.Equal(expected, actual)

    [<Theory>]
    [<InlineData("11200", true)>]
    [<InlineData("011A0", true)>]
    [<InlineData("12123", true)>]
    [<InlineData("112JB", true)>]
    [<InlineData("123JJ", true)>]
    [<InlineData("12122", false)>]
    [<InlineData("2Q1QQ", false)>]
    [<InlineData("12345", false)>]
    [<InlineData("11123", false)>]
    [<InlineData("21121", false)>]
    [<InlineData("AAAAA", false)>]
    let ``isTwoPair - Part 2`` (text: string, expected: bool) =
        let jokers = toCharList text|> List.filter (fun l -> l = 'J') |> List.length
        let actual = Day07.Part2.isTwoPair (toCharList text) jokers

        Assert.Equal(expected, actual)