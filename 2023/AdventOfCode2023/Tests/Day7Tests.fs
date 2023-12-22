module Day7Tests

open Xunit
open Common.Casting

[<Theory>]
[<InlineData("11111", true)>]
[<InlineData("QQQQQ", true)>]
[<InlineData("32T3K", false)>]
[<InlineData("12345", false)>]
[<InlineData("11112", false)>]
[<InlineData("21111", false)>]
let ``isFiveOfAKind`` (text: string, expected: bool) =

    let actual = Day07.isFiveOfAKind (toCharList text)

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

    let actual = Day07.isFourOfAKind (toCharList text)

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

    let actual = Day07.isFullHouse (toCharList text)

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

    let actual = Day07.isThreeOfAKind (toCharList text)

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

    let actual = Day07.isTwoPair (toCharList text)

    Assert.Equal(expected, actual)
