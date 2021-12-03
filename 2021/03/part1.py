import numpy as np
from utils import bit_array_to_decimal


def main():
    with open("03/input.txt", encoding="UTF-8") as file:
        content = file.read()
    numberOfBits = len(content.split("\n")[0])
    bits = [int(bit) for bit in list(content.replace("\n", ""))]
    report = np.array(bits).reshape(-1, numberOfBits)

    gamma = list()
    epsilon = list()
    for i in range(numberOfBits):
        gammaBit = np.bincount(report[0:, i]).argmax()
        gamma.append(gammaBit)
        epsilonBit = np.bincount(report[0:, i]).argmin()
        epsilon.append(epsilonBit)

    gammaDecimal = bit_array_to_decimal(gamma)
    epsilonDecimal = bit_array_to_decimal(epsilon)

    result = gammaDecimal * epsilonDecimal
    print(result)


if __name__ == "__main__":
    main()
