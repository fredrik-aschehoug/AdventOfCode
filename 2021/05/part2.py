import numpy as np
from utils import parse_lines, get_initial_matrix, is_horizontal_vertical_line, process_horizontal_vertical, get_line_range


def process_diagonal(lines, matrix):
    for line in lines:
        x_range = get_line_range(line, "x")
        y_range = get_line_range(line, "y")
        for i in range(len(x_range)):
            matrix[y_range[i]][x_range[i]] += 1


def main():
    with open("05/input.txt", encoding="UTF-8") as file:
        content = file.read()

    text_lines = content.split("\n")
    all_lines = [parse_lines(line) for line in text_lines]
    horizontal_vertical_lines = [line for line in all_lines if is_horizontal_vertical_line(line)]
    diagonal_lines = [line for line in all_lines if not is_horizontal_vertical_line(line)]

    matrix = get_initial_matrix(all_lines)

    process_horizontal_vertical(horizontal_vertical_lines, matrix)
    process_diagonal(diagonal_lines, matrix)

    result = np.count_nonzero(matrix >= 2)
    print(result)


if __name__ == "__main__":
    main()
