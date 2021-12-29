import json
from utils import do_homework, get_magnitude


def main():
    with open("18/input.txt", encoding="UTF-8") as file:
        lines = file.read().splitlines()

    result = do_homework(lines)

    magnitude = get_magnitude(json.loads(result))
    print("Magnitude: ", magnitude)


if __name__ == "__main__":
    main()
