// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System.IO

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let text = File.ReadAllText("Input/input-day5.txt")
    
    let message = Day05.part1 text
    printf $"Part 1 = {message}\n"
    0 // return an integer exit code