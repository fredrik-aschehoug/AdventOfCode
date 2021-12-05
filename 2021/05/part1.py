import numpy as np


def parse_coordinate(string):
    x, y = string.split(",")
    return {"x": int(x), "y": int(y)}


def parse_lines(line):
    source, destination = line.split(" -> ")

    coordinates = {
        "from": parse_coordinate(source),
        "to": parse_coordinate(destination)
    }
    return coordinates


# Only keep horizontal and vertical lines
def is_valid_line(line):
    if (line["from"]["x"] == line["to"]["x"]):
        return True
    if (line["from"]["y"] == line["to"]["y"]):
        return True
    return False


def get_axis(line):
    if (line["from"]["x"] == line["to"]["x"]):
        return "y"
    if (line["from"]["y"] == line["to"]["y"]):
        return "x"


def get_max_coordinate(lines, dimention):
    all_values = np.array([[line["from"][dimention], line["to"][dimention]] for line in lines]).flatten()
    return all_values.max()


def get_line_range(line, axis):
    if (line["from"][axis] < line["to"][axis]):
        return range(line["from"][axis], line["to"][axis] + 1)
    return range(line["to"][axis], line["from"][axis] + 1)


def get_initial_matrix(lines):
    max_x = get_max_coordinate(lines, "x") + 1
    max_y = get_max_coordinate(lines, "y") + 1

    matrix = np.zeros((max_y, max_x), dtype="i")
    return matrix


def main():
    with open("05/input.txt", encoding="UTF-8") as file:
        content = file.read()

    text_lines = content.split("\n")
    all_lines = [parse_lines(line) for line in text_lines]
    valid_lines = [line for line in all_lines if is_valid_line(line)]

    matrix = get_initial_matrix(valid_lines)

    for line in valid_lines:
        axis = get_axis(line)
        line_range = get_line_range(line, axis)
        for axis_i in line_range:
            if (axis == "y"):
                matrix[axis_i][line["from"]["x"]] += 1
            if (axis == "x"):
                matrix[line["from"]["y"]][axis_i] += 1

    result = np.count_nonzero(matrix >= 2)

    print(result)


if __name__ == "__main__":
    main()
