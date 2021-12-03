def bit_array_to_decimal(arr):
    bits_string = "".join([str(x) for x in arr])
    decimal = int(bits_string, 2)
    return decimal
