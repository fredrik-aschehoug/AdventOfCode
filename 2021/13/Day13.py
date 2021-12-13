from operator import itemgetter
import numpy as np


def get_instructions(content):
    lines = [instruction.replace("fold along ", "").split("=") for instruction in content.splitlines()]
    return [(x, int(y)) for (x, y) in lines]


def get_coordinates(content):
    coordinates = list()
    for line in content.splitlines():
        y, x = line.split(",")
        coordinates.append((int(x), int(y)))
    return coordinates


def get_matrix(coordinates, instructions):
    row_instruction = [x[1] for x in instructions[:2] if x[0] == "y"][0]
    col_instruction = [x[1] for x in instructions[:2] if x[0] == "x"][0]

    max_row = (row_instruction * 2) + 1
    max_col = (col_instruction * 2) + 1

    matrix = np.full((max_row, max_col), False)
    for (r, c) in coordinates:
        matrix[r, c] = True

    return matrix


def try_get(arr, x, y):
    try:
        val = arr[x, y]
    except:
        val = False
    return val


def fold_up(matrix, line):
    matrix = np.delete(matrix, line, 0)
    top = matrix[:line, :]
    bottom = matrix[line:, :]
    bottom = np.flip(bottom, 0)

    largest_shape = max(top.shape, bottom.shape)

    new_matrix = np.full(largest_shape, False)
    for x, y in np.ndindex(max(top.shape, bottom.shape)):
        new_matrix[x, y] = try_get(top, x, y) or try_get(bottom, x, y)
    return new_matrix


def fold_left(matrix, line):
    matrix = np.delete(matrix, line, 1)
    left = matrix[:, :line]
    right = matrix[:, line:]
    left = np.flip(left, 1)

    largest_shape = max(left.shape, right.shape)

    new_matrix = np.full(largest_shape, False)
    for x, y in np.ndindex(max(left.shape, right.shape)):
        new_matrix[x, y] = try_get(left, x, y) or try_get(right, x, y)
    return new_matrix


def main():
    with open("13/input.txt", encoding="UTF-8") as file:
        content = file.read()

    part1, part2 = content.split("\n\n")
    instructions = get_instructions(part2)
    coordinates = get_coordinates(part1)

    matrix = get_matrix(coordinates, instructions)

    part1_printed = False
    for axis, line in instructions:
        if (axis == "y"):
            matrix = fold_up(matrix, line)
        else:
            matrix = fold_left(matrix, line)

        if (not part1_printed):
            count = np.count_nonzero(matrix)
            print("Part 1: ", count)
            part1_printed = True

    print("Part 2:")
    for row in range(matrix.shape[0]):
        line = ["#" if point else " " for point in matrix[row]]
        line.reverse()
        print("".join(line))


if __name__ == "__main__":
    main()
