namespace Common

open System.Collections
open System.Linq

module Collections =
    let rec transpose2dList = function
    | [] -> failwith "cannot transpose a 0-by-n matrix"
    | []::xs -> [] 
    | xs -> List.map List.head xs :: transpose2dList (List.map List.tail xs)

    let toStack<'a> (l: Generic.IEnumerable<'a>) =
        let stack = new Generic.Stack<'a>()
        l |> Enumerable.ToArray |> Array.rev |> Array.iter(fun item -> stack.Push(item))
        stack

    let toQueue<'a> (l: Generic.IEnumerable<'a>) =
        let queue = new Generic.Queue<'a>()
        l |> Enumerable.ToArray |> Array.iter(fun item -> queue.Enqueue(item))
        queue

    let toTuple (pair: array<'a>) = (pair.[0], pair.[1])

