open System

let readText filePath = System.IO.File.ReadAllText(filePath)

let splitDoubleNewline (text: string) = text.Split("\r\n\r\n")
let splitNewline (text: string) = text.Split("\r\n")
let castToInt (lines: string[]) = Array.map Int32.Parse lines

let getElvesCalories (text: string) =
    splitDoubleNewline text
    |> Array.map splitNewline
    |> Array.map castToInt
    |> Array.map Array.sum

[<EntryPoint>]
let main argv =
    let text = readText "input.txt"
    let elves = getElvesCalories text
    let topElf = Array.max elves
    printf $"Top calories = {topElf}"
    
    0 // return an integer exit code