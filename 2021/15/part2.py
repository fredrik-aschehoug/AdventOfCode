import numpy as np
from Searcher import Searcher
from utils import get_matrix


def extend_dimention(matrix, dimention):
    length = 4
    previous = matrix

    for i in range(length):
        extension = previous + 1
        extension = np.where(extension > 9, 1, extension)
        previous = extension
        matrix = np.concatenate((matrix, extension), axis=dimention)
    return matrix


def extend_matrix(matrix):
    # Extend column-wize
    matrix = extend_dimention(matrix, 1)
    # Extend row-wize
    matrix = extend_dimention(matrix, 0)

    return matrix


def main():
    with open("15/input.txt", encoding="UTF-8") as file:
        content = file.read()

    matrix = get_matrix(content)
    matrix = extend_matrix(matrix)
    searcher = Searcher(matrix)
    path = searcher.get_shortest_path()

    print(path)


if __name__ == "__main__":
    main()
