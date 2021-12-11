from Solver import Solver1


def main():
    with open("11/input.txt", encoding="UTF-8") as file:
        content = file.read()

    solver = Solver1(content)
    solver.iterate(100)
    print(solver.flashes)


if __name__ == "__main__":
    main()
