namespace Common

open System

module Casting =
    let toString x = x.ToString()

    let stringToInt = Int32.Parse

    let stringToFloat = Int32.Parse >> float

    let charToInt (c: char) = stringToInt (toString c)

    let tryToInt (s: string) = 
        match Int32.TryParse s with
        | true, v -> Some v
        | false, _ -> None

    let toCharArray (x: string) = x.ToCharArray()

    let toCharList = toCharArray >> Array.toList