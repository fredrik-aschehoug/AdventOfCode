from utils import bin_to_dec, parse_operator, hex_to_bin
from math import prod


def get_literal_value(packet):
    rest = packet
    result = ""
    while True:
        current = rest[:5]
        result += rest[1:5]
        rest = rest[5:]
        if current[-5] == "0":
            return bin_to_dec(result)


def parse_packet(packet):
    version = bin_to_dec(packet[:3])
    type_id = bin_to_dec(packet[3:6])

    # If Literal
    if type_id == 4:
        return get_literal_value(packet[6:])

    # If operator
    sub_packets = parse_operator(packet[6:])
    values = [parse_packet(sub_packet) for sub_packet in sub_packets]

    if type_id == 0:
        return sum(values)
    if type_id == 1:
        return prod(values)
    if type_id == 2:
        return min(values)
    if type_id == 3:
        return max(values)
    if type_id == 5:
        return 1 if values[0] > values[1] else 0
    if type_id == 6:
        return 1 if values[0] < values[1] else 0
    if type_id == 7:
        return 1 if values[0] == values[1] else 0


def main():
    with open("16/input.txt", encoding="UTF-8") as file:
        content = file.read()

    # hex -> binary. 1 hex char -> 4 bits
    all_bits = [hex_to_bin(char) for char in list(content)]
    message = "".join(all_bits)

    result = parse_packet(message)

    print(result)


if __name__ == "__main__":
    main()
