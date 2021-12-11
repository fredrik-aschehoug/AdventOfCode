import numpy as np


from Solver import Solver2


def main():
    with open("11/input.txt", encoding="UTF-8") as file:
        content = file.read()

    solver = Solver2(content)
    step = solver.iterate()
    print(step)


if __name__ == "__main__":
    main()
