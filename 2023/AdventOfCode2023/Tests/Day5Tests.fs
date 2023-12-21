module Day5Tests

open Xunit
open Day05.Common
open Day05.Part2;

[<Theory>]
[<InlineData(15L, 20L, true)>]
[<InlineData(15L, 30L, true)>]
[<InlineData(5L, 15L, true)>]
[<InlineData(10L, 15L, true)>]
[<InlineData(40L, 50L, false)>]
[<InlineData(1L, 2L, false)>]
let ``isPartialMatch`` (rangeStart: int64, rangeEnd: int64, expected: bool) =
    let mapItem = { SourceStart = 10L; DestinationStart = 20L; Length = 11L }
    let range = { Start = rangeStart; End = rangeEnd }
    let actual = Day05.Part2.isPartialMatch range mapItem

    Assert.Equal(expected, actual)