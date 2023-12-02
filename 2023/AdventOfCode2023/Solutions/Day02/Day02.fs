module Day02

open System

type Color =
    | Red = 0
    | Green = 1
    | Blue = 2

type Bag =
    { Red: int;
      Green: int;
      Blue: int; }

type Item = { Color: Color; Quantity: int; }
type Game = { Id: int; Bags: Bag[] }

let elfBag = { Red = 12; Green = 13; Blue = 14; }

let splitLine (text: string) = text.Split("\r\n")

let parseId (text: string) =
    Int32.Parse (text.Replace("Game ", ""))

let parseColor text =
    match text with
    | "red" -> Color.Red
    | "green" -> Color.Green
    | "blue" -> Color.Blue
    | _ -> failwith("Unknown color")

let parseItem (text: string) =
    let parts = text.Split(" ")
    { Quantity = Int32.Parse parts.[0]; Color = parseColor parts.[1] }

let foldBag (acc: Bag) (item: Item) =
    match item.Color with
    | Color.Red -> { acc with Red = item.Quantity }
    | Color.Green -> { acc with Green = item.Quantity }
    | Color.Blue -> { acc with Blue = item.Quantity }
    | _ -> failwith("Unknown color")

let parseBag (text: string) =
    let bag = { Red = 0; Green = 0; Blue = 0; }
    let items = text.Split(", ") |> Array.map parseItem
    Array.fold foldBag bag items

let parseBags (text: string) =
    text.Split("; ") |> Array.map parseBag

let parseGame (line: string) =
    let parts = line.Split(": ")
    let id = parseId parts.[0]
    let bags = parseBags parts.[1]
    { Id = id; Bags = bags; }

let getMaxValue (item: Item) =
    match item.Color with
    | Color.Red -> elfBag.Red
    | Color.Green -> elfBag.Green
    | Color.Blue -> elfBag.Blue
    | _ -> failwith("Unknown color")

let bagIsValid (bag: Bag) = 
    bag.Red <= elfBag.Red &&
    bag.Green <= elfBag.Green &&
    bag.Blue <= elfBag.Blue

let gameIsValid (game: Game) =
    Array.forall bagIsValid game.Bags

let part1 text =
    splitLine text
    |> Array.map parseGame
    |> Array.filter gameIsValid
    |> Array.sumBy(fun game -> game.Id)

let part2 =
    1