module Day07

open System.Collections.Generic
open System

type Command =
    | Cd = 0
    | Ls = 1
    | Unknown = 2

let getCommandType (command: string) =
    if command.StartsWith("$ cd") then Command.Cd
    else if command.StartsWith("$ ls") then Command.Ls
    else Command.Unknown

let parseCd (command: string) = command.Remove(0, 5)
let parseDirName (command: string) = command.Remove(0, 4)

let rec getFiles (index: int) (commands: string[]) (result: int list) =
    if index = commands.Length then (index, result)
    else
        let line = commands.[index]
        if line.StartsWith("$") then (index, result) // Done reading
        elif line.StartsWith("dir") then getFiles (index + 1) commands result // Skip line
        else // Parse line
            let size = Int32.Parse(line.Split().[0])
            getFiles (index + 1) commands (size :: result)

let rec getDirectories (index: int) (commands: string[]) (result: string list) =
    if index = commands.Length then (index, result)
    else
        let line = commands.[index]
        if line.StartsWith("$") then (index, result) // Done reading
        elif line.StartsWith("dir") then getDirectories (index + 1) commands (parseDirName line :: result) // parse line
        else // Skip line
            getDirectories (index + 1) commands result

let getDirectoryContents (index: int) (commands: string[]) =
    let nextIndex, files = getFiles index commands []
    let nextIndex', dirs = getDirectories index commands []

    let nextIndex'' = Math.Max(nextIndex, nextIndex')
    (nextIndex'', List.sum files)

let rec getDirectoriesFlatRec (commands: string[]) i (dirPath: string list) (dirMap: IDictionary<string, int>) =
    if i >= Array.length commands then dirMap else
    let command = commands.[i]
    let commandType = getCommandType command
    match commandType with
    | Command.Cd ->
        match parseCd command with
        | ".." -> getDirectoriesFlatRec commands (i+1) dirPath[..dirPath.Length - 2] dirMap
        | _ -> getDirectoriesFlatRec commands (i+1) (dirPath @ [parseCd command]) dirMap
    | Command.Ls -> 
        let nextIndex, size = getDirectoryContents (i + 1) commands
        dirMap.Add((String.concat "/" dirPath), size)
        getDirectoriesFlatRec commands nextIndex dirPath dirMap

let getCumulativeSize (dirName: string) (dirMap: IDictionary<string, int>) =
    Seq.zip dirMap.Keys dirMap.Values
    |> Seq.filter(fun (k,v) -> k.StartsWith(dirName))
    |> Seq.sumBy(fun (k,v) -> v)

let getDirectoriesFlat (commands: string[]) =
    let directories = new Dictionary<string, int>()
    getDirectoriesFlatRec commands 0 [] directories

let isLessThan100k x = x < 100000

let part1 (commands: string[]) =
    let (directoryMap: IDictionary<string,int>) = getDirectoriesFlat commands
    let directoryNames = directoryMap.Keys |> Seq.distinct
    
    [|for dir in directoryNames do getCumulativeSize dir directoryMap|]
    |> Array.filter isLessThan100k
    |> Array.sum
