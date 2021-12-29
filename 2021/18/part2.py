import json
from utils import do_homework, get_magnitude
from itertools import permutations


def main():
    with open("18/input.txt", encoding="UTF-8") as file:
        lines = file.read().splitlines()

    pairs = permutations(lines, 2)

    max_magnitude = 0
    for pair in pairs:
        result = do_homework(pair)
        magnitude = get_magnitude(json.loads(result))
        if magnitude > max_magnitude:
            max_magnitude = magnitude
    print("Max magnitude: ", max_magnitude)


if __name__ == "__main__":
    main()
