from utils import get_network
from PathFinder import PathFinder1, PathFinder2


def main():
    with open("12/input.txt", encoding="UTF-8") as file:
        lines = file.read().splitlines()

    network = get_network(lines)
    pathfinder = PathFinder1(network)
    paths = pathfinder.get_distinct_paths()

    print("Part 1: ", len(paths))

    network = get_network(lines, part2=True)
    pathfinder = PathFinder2(network)
    paths = pathfinder.get_distinct_paths()

    print("Part 2: ", len(paths))


if __name__ == "__main__":
    main()
