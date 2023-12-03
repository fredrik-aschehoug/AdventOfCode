module Day01

open System.Text.RegularExpressions
open System
open Common.Casting
open Common.Parsing

let pattern = @"one|two|three|four|five|six|seven|eight|nine|\d"
let digitRx = Regex(@"\d", RegexOptions.Compiled)
let spelledDigitRx = Regex(pattern, RegexOptions.Compiled)
let spelledDigitRxRtl = Regex(pattern, RegexOptions.RightToLeft)

let mapSpelled text =
    match text with
    | "one"    -> "1"
    | "two"    -> "2"
    | "three"  -> "3"
    | "four"   -> "4"
    | "five"   -> "5"
    | "six"    -> "6"
    | "seven"  -> "7"
    | "eight"  -> "8"
    | "nine"   -> "9"
    | _        -> failwith("Unknown text!")

let mapSpelledToDigit (text: string) =
    if digitRx.IsMatch(text) then text else mapSpelled text

let getNumber (chars: char[]) =
    let matches = chars |> Array.map toString |> Array.toList |> List.filter digitRx.IsMatch
    Int32.Parse $"{List.head matches}{List.last matches}"

let getNumberAdvanced (line: string) =
    let first = mapSpelledToDigit (spelledDigitRx.Match(line).Value)
    let last = mapSpelledToDigit (spelledDigitRxRtl.Match(line).Value)
    Int32.Parse $"{first}{last}"

let part1 =
    splitNewline
    >> Array.map toCharArray
    >> Array.map getNumber
    >> Array.sum

let part2 =
    splitNewline
    >> Array.map getNumberAdvanced
    >> Array.sum