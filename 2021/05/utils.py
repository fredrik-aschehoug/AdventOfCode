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
        return list(range(line["from"][axis], line["to"][axis] + 1))
    return list(reversed(range(line["to"][axis], line["from"][axis] + 1)))


def get_initial_matrix(lines):
    max_x = get_max_coordinate(lines, "x") + 1
    max_y = get_max_coordinate(lines, "y") + 1

    matrix = np.zeros((max_y, max_x), dtype="i")
    return matrix


def is_horizontal_vertical_line(line):
    if (line["from"]["x"] == line["to"]["x"]):
        return True
    if (line["from"]["y"] == line["to"]["y"]):
        return True
    return False


def process_horizontal_vertical(lines, matrix):
    for line in lines:
        axis = get_axis(line)
        line_range = get_line_range(line, axis)
        for axis_i in line_range:
            if (axis == "y"):
                matrix[axis_i][line["from"]["x"]] += 1
            if (axis == "x"):
                matrix[line["from"]["y"]][axis_i] += 1
