module Day02

open Common.Parsing
open Common.Casting

let rec listChecker list matcher =
    match list with
    | [] -> true
    | [x] -> true
    | x::y::xs -> 
        if (matcher x y) then listChecker (y::xs) matcher
        else false

let rec isAscending report =
    listChecker report (fun x y -> x <= y)

let rec isDescending report = 
    listChecker report (fun x y -> x >= y)

let differByAtLeastOne x y =
    abs (x - y) >= 1

let differByAtmostThree x y =
    abs (x - y) <= 3

let hasCorrectAdjacenty x y =
    differByAtLeastOne x y && differByAtmostThree x y

let rec reportHasCorrectAdjacency report =
    listChecker report hasCorrectAdjacenty

let reportIsSafe report =
    let isSorted = isAscending report || isDescending report
    isSorted && reportHasCorrectAdjacency report

let rec remove i l =
    match i, l with
    | 0, x::xs -> xs
    | i, x::xs -> x::remove (i - 1) xs
    | i, [] -> l

let reportIsSafeV2 (report: int list) =
    let initiallySafe = reportIsSafe report
    let safeReports = [for i in 0 .. report.Length -> report] |> List.mapi (fun i x -> reportIsSafe (remove i x)) |> List.filter (fun x -> x = true)
    initiallySafe || safeReports.Length >= 1

let validateReports validator reports =
    reports
    |> splitNewline
    |> Array.map (splitText " ")
    |> Array.map (Array.map stringToInt)
    |> Array.map Array.toList
    |> Array.map validator
    |> Array.filter (fun x -> x)
    |> Array.length

let part1 =
    validateReports reportIsSafe
    
let part2 =
    validateReports reportIsSafeV2
