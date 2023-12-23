module Day07.Common

type HandType =
    | HighCard = 0
    | Pair = 1
    | TwoPair = 2
    | ThreeOfAKind = 3
    | FullHouse = 4
    | FourOfAKind = 5
    | FiveOfAKind = 6

type Hand = { Type: HandType; Labels: int list; Bid: int; Rank: int; Original: string; }

let defaultHand = { Type = HandType.HighCard; Labels = []; Bid = 0; Rank = 0; Original = "" }

let isGreater (zipped: (int*int)) =
    match zipped with 
    | (x,y) when x > y -> true
    | _ -> false

let rec handIsGreater (zipped: (int*int) list) = 
    match zipped with
    | [] -> 0
    | (x,y)::xs when x = y -> handIsGreater xs
    | x::xs ->  if isGreater x then -1 else 1
    
let handComparer (h1: Hand) (h2: Hand) =
    List.zip h1.Labels h2.Labels |> handIsGreater

let setRank ((rank, hand): (int*Hand)) =
    { hand with Rank = rank }

let getScore hand =
    hand.Rank * hand.Bid