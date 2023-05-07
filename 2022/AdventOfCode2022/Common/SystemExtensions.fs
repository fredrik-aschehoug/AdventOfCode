namespace Common

open System

module SystemExtensions =
    type System.String with
        member this.ToInt = Int32.Parse this
        member this.ToFloat = this |> Int32.Parse |> float
