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

let rec getFiles (index: int) (commands: string[]) (result: int list) =
    if index = commands.Length then (index, result)
    else
        let line = commands.[index]
        if line.StartsWith("$") then (index, result) // Done reading
        elif line.StartsWith("dir") then getFiles (index + 1) commands result // Skip line
        else // Parse line
            let size = Int32.Parse(line.Split().[0])
            getFiles (index + 1) commands (size :: result)

let rec getDirectoriesNextIndex (index: int) (commands: string[]) =
    if index = commands.Length then index
    else
        let line = commands.[index]
        if line.StartsWith("$") then index // Done reading
        elif line.StartsWith("dir") then getDirectoriesNextIndex (index + 1) commands // parse line
        else // Skip line
            getDirectoriesNextIndex (index + 1) commands

let getDirectoryContents (index: int) (commands: string[]) =
    let nextIndex, files = getFiles index commands []
    let nextIndex' = getDirectoriesNextIndex index commands

    let nextIndex'' = Math.Max(nextIndex, nextIndex')
    (nextIndex'', List.sum files)

let rec getDirectoriesMapRec (commands: string[]) i (dirPath: string list) (dirMap: IDictionary<string, int>) =
    if i >= Array.length commands then dirMap else
    let command = commands.[i]
    let commandType = getCommandType command
    match commandType with
    | Command.Cd ->
        match parseCd command with
        | ".." -> getDirectoriesMapRec commands (i+1) dirPath[..dirPath.Length - 2] dirMap
        | _ -> getDirectoriesMapRec commands (i+1) (dirPath @ [parseCd command]) dirMap
    | Command.Ls -> 
        let nextIndex, size = getDirectoryContents (i + 1) commands
        dirMap.Add((String.concat "/" dirPath), size)
        getDirectoriesMapRec commands nextIndex dirPath dirMap

let getCumulativeSize (dirName: string) (dirMap: IDictionary<string, int>) =
    Seq.zip dirMap.Keys dirMap.Values
    |> Seq.filter(fun (k,v) -> k.StartsWith(dirName))
    |> Seq.sumBy(fun (k,v) -> v)

let getDirectoriesMap (commands: string[]) =
    let directories = new Dictionary<string, int>()
    getDirectoriesMapRec commands 0 [] directories

let isLessThan100k x = x < 100000

let getDirectoryCumulativeSizes commands =
    let (directoryMap: IDictionary<string,int>) = getDirectoriesMap commands
    let directoryNames = directoryMap.Keys |> Seq.distinct
    
    [|for dir in directoryNames do getCumulativeSize dir directoryMap|]

let part1 =
    getDirectoryCumulativeSizes
    >> Array.filter isLessThan100k
    >> Array.sum

let part2 (commands: string[]) =
    let capacity = 70000000
    let minimumUnused = 30000000

    let sizes = getDirectoryCumulativeSizes commands |> Array.sortDescending |> List.ofArray
    let usedSpace = sizes.Head
    let currentUnusedSpace = capacity - usedSpace
    let spaceNeeded = minimumUnused - currentUnusedSpace

    sizes |> List.filter(fun x -> x >= spaceNeeded) |> List.sort |> List.head
