module Day03

open Common.Casting
open System.Text.RegularExpressions

let instructionsRx = Regex(@"mul\((\d+),(\d+)\)", RegexOptions.Compiled)
let enableDisableRx = Regex(@"do\(\)|don't\(\)", RegexOptions.Compiled)

type EnableDisableMatch = { Value: string; Start: int; Stop: int; }

let part1 text =
    let matches = instructionsRx.Matches(text)
    seq {for m in matches do yield m.Groups[1].Value, m.Groups[2].Value}
        |> Seq.map (fun (x,y) -> stringToInt x, stringToInt y)
        |> Seq.map (fun (x,y) -> x * y)
        |> Seq.sum

let computeLastPart (text: string) instruction =
    match instruction.Value with
    | "do()" -> text[instruction.Stop..]
    | "don't()" -> ""
    | _ -> failwith "Unknown instruction"

let part2 (input: string) =
    let text = "do()" + input

    let folder (acc: string) ((current, next): EnableDisableMatch*EnableDisableMatch) =
        match current.Value with
        | "do()" -> acc + text[current.Stop..next.Start]
        | "don't()" -> acc
        | _ -> failwith "Unknown instruction"

    let matches =
        seq {for m in enableDisableRx.Matches(text) do yield { Value = m.Value; Start = m.Index; Stop = m.Index + m.Length; } }
        
    let folded = ("", matches |> Seq.pairwise) ||> Seq.fold folder
    let result = folded + computeLastPart text (matches |> Seq.last)
    
    part1 result