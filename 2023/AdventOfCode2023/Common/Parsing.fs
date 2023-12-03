namespace Common

module Parsing =
    let splitDoubleNewline (text: string) = text.Split("\r\n\r\n")
    let splitNewline (text: string) = text.Split("\r\n")
