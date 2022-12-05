module Day05

open Xunit

[<Theory>]
[<InlineData(0, 1)>]
[<InlineData(1, 5)>]
[<InlineData(2, 9)>]
[<InlineData(3, 13)>]
[<InlineData(4, 17)>]
let ``getStackPosition`` (stackNo, stackIndex) =
    let actual = Day05.getStackPosition stackNo

    Assert.Equal(stackIndex, actual)
