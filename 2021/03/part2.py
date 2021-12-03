import numpy as np
from utils import bit_array_to_decimal


def get_oxygen_bit(arr):
    bincount = np.bincount(arr)
    bit = 1
    if (bincount.size == 1):
        return arr[0]
    if (not np.all(bincount == bincount[0])):
        bit = bincount.argmax()
    return bit


def get_c02_bit(arr):
    bincount = np.bincount(arr)
    bit = 0
    if (bincount.size == 1):
        return arr[0]
    if (not np.all(bincount == bincount[0])):
        bit = bincount.argmin()
    return bit


def get_oxygen(report, index):
    num_rows, num_cols = report.shape
    if (num_rows == 1):
        return report

    bit = get_oxygen_bit(report[0:, index])

    filter = np.asarray([bit])
    mask = np.in1d(report[:, index], filter)
    return get_oxygen(report[mask], index + 1)


def get_c02(report, index):
    num_rows, num_cols = report.shape
    if (num_rows == 1):
        return report

    bit = get_c02_bit(report[0:, index])

    filter = np.asarray([bit])
    mask = np.in1d(report[:, index], filter)
    return get_c02(report[mask], index + 1)


def main():
    with open("03/input.txt", encoding="UTF-8") as file:
        content = file.read()
    numberOfBits = len(content.split("\n")[0])
    bits = [int(bit) for bit in list(content.replace("\n", ""))]
    report = np.array(bits).reshape(-1, numberOfBits)

    oxygenBits = get_oxygen(report, 0)
    co2Bits = get_c02(report, 0)
    oxygen = bit_array_to_decimal(oxygenBits[0])
    c02 = bit_array_to_decimal(co2Bits[0])

    result = oxygen * c02
    print(result)


if __name__ == "__main__":
    main()
