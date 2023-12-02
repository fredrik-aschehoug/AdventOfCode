module Day02

open System.Text.RegularExpressions
open System

// 12 red cubes, 13 green cubes, and 14 blue cubes

type Color =
    | Red = 0
    | Green = 1
    | Blue = 2

type Bag =
    { Red: int;
      Green: int;
      Blue: int; }

type Item = { Color: Color; Quantity: int; }
type Game = { Id: int; Items: Item[] }

let bag = { Red = 12; Green = 13; Blue = 14; }

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

let parseItems (text: string) =
    text.Replace(";", ",").Split(", ") |> Array.map parseItem

let parseGame (line: string) =
    let parts = line.Split(": ")
    let id = parseId parts.[0]
    let items = parseItems parts.[1]
    { Id = id; Items = items; }

let getMaxValue (item: Item) =
    match item.Color with
    | Color.Red -> bag.Red
    | Color.Green -> bag.Green
    | Color.Blue -> bag.Blue
    | _ -> failwith("Unknown color")

let itemIsValid (item: Item) = 
    let max = getMaxValue item
    item.Quantity <= max

let gameIsValid (game: Game) =
    Array.forall itemIsValid game.Items

let part1 text =
    splitLine text
    |> Array.map parseGame
    |> Array.filter gameIsValid
    |> Array.sumBy(fun game -> game.Id)

let part2 =
    1