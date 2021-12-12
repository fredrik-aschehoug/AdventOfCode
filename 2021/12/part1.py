from utils import get_network
from PathFinder import PathFinder


def main():
    with open("12/input.txt", encoding="UTF-8") as file:
        lines = file.read().splitlines()

    network = get_network(lines)
    pathfinder = PathFinder(network)
    paths = pathfinder.get_distinct_paths()

    print(len(paths))


if __name__ == "__main__":
    main()
