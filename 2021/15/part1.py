import numpy as np
from Searcher import Searcher
from utils import get_matrix


def main():
    with open("15/input.txt", encoding="UTF-8") as file:
        content = file.read()

    matrix = get_matrix(content)
    searcher = Searcher(matrix)
    path = searcher.get_shortest_path()

    print(path)


if __name__ == "__main__":
    main()
