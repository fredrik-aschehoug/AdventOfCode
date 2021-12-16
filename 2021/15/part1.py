import numpy as np
from Searcher import Searcher


def get_matrix(file_content):
    columns = len(file_content.split("\n")[0])
    nodes = [int(level) for level in list(file_content.replace("\n", ""))]
    matrix = np.array(nodes).reshape(-1, columns)
    return matrix


def main():
    with open("15/input.txt", encoding="UTF-8") as file:
        content = file.read()

    matrix = get_matrix(content)
    searcher = Searcher(matrix)
    path = searcher.get_shortest_path()

    print(path)


if __name__ == "__main__":
    main()
