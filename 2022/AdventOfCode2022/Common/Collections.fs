namespace Common

module Collections =
    let rec transpose2dList = function
    | [] -> failwith "cannot transpose a 0-by-n matrix"
    | []::xs -> [] 
    | xs -> List.map List.head xs :: transpose2dList (List.map List.tail xs)

