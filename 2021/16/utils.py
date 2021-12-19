def hex_to_bin(char):
    scale = 16  # base16
    num_of_bits = 4  # pad leading zeros
    return bin(int(char, scale))[2:].zfill(num_of_bits)


def bin_to_dec(bin):
    return int(bin, 2)


def get_literal_packet(packet):
    rest = packet
    result = ""
    while True:
        result += rest[:5]
        rest = rest[5:]
        if result[-5] == "0":
            return result


def get_operator_packet(packet):
    length_type = packet[:1]
    if length_type == "0":
        total_length = bin_to_dec(packet[1:16])
        result = packet[:16 + total_length]
    else:
        num_sub_packets = bin_to_dec(packet[1:12])
        packets = parse_packets_by_cardinality(packet[12:], num_sub_packets)
        result = packet[:12] + "".join(packets)
    return result


def parse_packets_by_length(packet, lenght):
    packet_rest = packet
    packets = list()
    while len("".join(packets)) < lenght:
        version = bin_to_dec(packet_rest[:3])
        type_id = bin_to_dec(packet_rest[3:6])
        if type_id == 4:
            current_packet = get_literal_packet(packet_rest[6:])
        else:
            current_packet = get_operator_packet(packet_rest[6:])
        packets.append(packet_rest[:len(current_packet) + 6])
        packet_rest = packet_rest[len(current_packet) + 6:]
    return packets


def parse_packets_by_cardinality(packet, lenght):
    packet_rest = packet
    packets = list()
    while len(packets) < lenght:
        version = bin_to_dec(packet_rest[:3])
        type_id = bin_to_dec(packet_rest[3:6])
        if type_id == 4:
            current_packet = get_literal_packet(packet_rest[6:])
        else:
            current_packet = get_operator_packet(packet_rest[6:])
        packets.append(packet_rest[:len(current_packet) + 6])
        packet_rest = packet_rest[len(current_packet) + 6:]
    return packets


def parse_operator(packet):
    length_type = packet[:1]
    packets = list()
    if length_type == "0":
        total_length = bin_to_dec(packet[1:16])
        packets = parse_packets_by_length(packet[16:], total_length)
        return packets

    num_sub_packets = bin_to_dec(packet[1:12])
    packets = parse_packets_by_cardinality(packet[12:], num_sub_packets)
    return packets
