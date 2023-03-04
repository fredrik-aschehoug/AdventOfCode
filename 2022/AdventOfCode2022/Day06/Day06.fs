module Day06

let isAllDistinct text =
    let distinct = Array.distinct text
    distinct.Length = text.Length

let rec getPacketStart (buffer: string) i lenght =
    let section = buffer.[i..(i + lenght)].ToCharArray()
    if isAllDistinct section then i + lenght + 1
    else getPacketStart buffer (i + 1) lenght

let part1 buffer = getPacketStart buffer 0 3

let part2 buffer = getPacketStart buffer 0 13

