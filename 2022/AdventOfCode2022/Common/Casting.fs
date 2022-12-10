namespace Common

open System

module Casting =
    let toString x = x.ToString()
    
    let stringToInt = Int32.Parse

    let charToInt (c: char) = stringToInt (toString c)
