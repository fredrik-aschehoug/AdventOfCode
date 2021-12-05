import numpy as np
from utils import parse_lines, get_initial_matrix, is_horizontal_vertical_line, process_horizontal_vertical


def main():
    with open("05/input.txt", encoding="UTF-8") as file:
        content = file.read()

    text_lines = content.split("\n")
    all_lines = [parse_lines(line) for line in text_lines]
    valid_lines = [line for line in all_lines if is_horizontal_vertical_line(line)]

    matrix = get_initial_matrix(valid_lines)

    process_horizontal_vertical(valid_lines, matrix)

    result = np.count_nonzero(matrix >= 2)
    print(result)


if __name__ == "__main__":
    main()
