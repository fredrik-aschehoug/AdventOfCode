module Day13

open Common
open System

let parsePacket (packet: string) = packet.ToCharArray()

let hasMore x = x = "," || x = "["

let getItem (packet: char[], index) =
    if Char.IsDigit packet.[index] && Char.IsDigit packet.[index + 1] then String.Join("", packet.[index .. index + 1])
    else packet.[index].ToString()

let removeDoubleDigit (item: string, packet: char[], index: int) =
    if item.Length > 1 then Array.concat [| packet.[..index]; packet.[index + 2..]; |]
    else packet

let wrapNumber (packet: char[], item: string, index) =
    Array.concat [| packet.[..index - 1]; [| '[' |]; item.ToCharArray(); [| ']' |]; packet.[index + 1 ..] |]

let rec pairIsInOrder (pair: char[] * char[], index) =
    let leftPacket, rightPacket = pair;
    let left, right = getItem (leftPacket, index), getItem (rightPacket, index)
    let leftNumber, rightNumber = Casting.tryToInt left, Casting.tryToInt right

    if leftNumber.IsSome && rightNumber.IsSome then
        if leftNumber.Value = rightNumber.Value then
            let newLeft = removeDoubleDigit (left, leftPacket, index)
            let newRight = removeDoubleDigit (right, rightPacket, index)
            pairIsInOrder ((newLeft, newRight), index + 1)
        elif leftNumber.Value < rightNumber.Value then true
        else false
    elif left = "," && right = "," then pairIsInOrder (pair, index + 1)
    elif left = "[" && right = "[" then pairIsInOrder (pair, index + 1)
    elif left = "]" && right = "]" then pairIsInOrder (pair, index + 1)
    elif left = "]" && (hasMore right || rightNumber.IsSome) then true
    elif (hasMore left || leftNumber.IsSome) && right = "]" then false
    elif leftNumber.IsSome && right = "[" then
        let newLeft = wrapNumber (leftPacket, left, index)
        pairIsInOrder ((newLeft, rightPacket), index + 1)
    elif left = "[" && rightNumber.IsSome then
        let newRight = wrapNumber (rightPacket, right, index)
        pairIsInOrder ((leftPacket, newRight), index + 1)
    else false // Should never hit this

let part1 =
    Text.splitDoubleNewline
    >> Array.map Text.splitNewline
    >> Array.map(fun pair -> Array.map parsePacket pair)
    >> Array.map Collections.toTuple
    >> Array.map(fun pair -> pairIsInOrder(pair, 1))
    >> Array.indexed
    >> Array.filter(fun (index, isInOrder) -> isInOrder)
    >> Array.sumBy(fun (index, isInOrder) -> index + 1)

let part2 (text: string) = 0