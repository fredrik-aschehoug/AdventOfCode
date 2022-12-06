module Day06

let isDistinct (text: char[]) =
    let distinct = Array.distinct text
    distinct.Length = text.Length

let rec getPacketStart (buffer: string, i: int, lenght: int) =
    let section = buffer.[i..(i + lenght)].ToCharArray()
    if (isDistinct section) then i + lenght + 1
    else getPacketStart (buffer, i + 1, lenght)

let part1 (buffer: string) = getPacketStart (buffer, 0, 3)

let part2 (buffer: string) = getPacketStart (buffer, 0, 13)

