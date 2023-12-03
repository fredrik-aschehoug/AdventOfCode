module Day02

open System
open Common.Parsing

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

let bagFolder (acc: Bag) (item: Item) =
    match item.Color with
    | Color.Red -> { acc with Red = item.Quantity }
    | Color.Green -> { acc with Green = item.Quantity }
    | Color.Blue -> { acc with Blue = item.Quantity }
    | _ -> failwith("Unknown color")

let parseBag (text: string) =
    let bag = { Red = 0; Green = 0; Blue = 0; }
    let items = text.Split(", ") |> Array.map parseItem
    Array.fold bagFolder bag items

let parseBags (text: string) =
    text.Split("; ") |> Array.map parseBag

let parseGame (line: string) =
    let parts = line.Split(": ")
    { Id = parseId parts.[0]; Bags = parseBags parts.[1]; }

let bagIsValid (bag: Bag) = 
    bag.Red <= elfBag.Red &&
    bag.Green <= elfBag.Green &&
    bag.Blue <= elfBag.Blue

let gameIsValid (game: Game) =
    Array.forall bagIsValid game.Bags

let getMinimumBag (game: Game) =
    let redBag = Array.maxBy(fun x -> x.Red) game.Bags
    let greenBag = Array.maxBy(fun x -> x.Green) game.Bags
    let blueBag = Array.maxBy(fun x -> x.Blue) game.Bags
    { Red = redBag.Red; Green = greenBag.Green; Blue = blueBag.Blue;}

let getBagPower (bag: Bag) =
    bag.Red * bag.Green * bag.Blue

let part1 =
    splitNewline
    >> Array.map parseGame
    >> Array.filter gameIsValid
    >> Array.sumBy(fun game -> game.Id)

let part2 =
    splitNewline
    >> Array.map parseGame
    >> Array.map getMinimumBag
    >> Array.map getBagPower
    >> Array.sum