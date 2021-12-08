import numpy as np


def main():
    simple_digit_lenghts = [2, 3, 4, 7]
    with open("08/input.txt", encoding="UTF-8") as file:
        content = file.read()
    lines = [line.split(" | ")[1] for line in content.splitlines()]
    all_digits = np.asarray([segments.split() for segments in lines]).flatten()
    simple_digits = [digit for digit in all_digits if len(digit) in simple_digit_lenghts]

    print(len(simple_digits))


if __name__ == "__main__":
    main()
