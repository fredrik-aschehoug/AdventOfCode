from utils import bin_to_dec, parse_operator, hex_to_bin


def parse_packet(packet):
    version = bin_to_dec(packet[:3])
    type_id = bin_to_dec(packet[3:6])

    # If Literal
    if type_id == 4:
        return version

    # If operator
    sub_packets = parse_operator(packet[6:])

    for sub_packet in sub_packets:
        version += parse_packet(sub_packet)
    return version


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
