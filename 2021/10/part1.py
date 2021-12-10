
character_map = {
    ")": "(",
    "]": "[",
    "}": "{",
    ">": "<"
}

points_map = {
    ")": 3,
    "]": 57,
    "}": 1197,
    ">": 25137
}


def check_line(line):
    stack = list()
    for character in line:
        if (character in character_map.values()):
            stack.append(character)
            continue
        if (character_map[character] != stack[-1]):
            return points_map[character]
        stack.pop()
    return 0


def main():
    with open("10/input.txt", encoding="UTF-8") as file:
        lines = file.read().splitlines()

    score = 0
    for line in lines:
        score += check_line(line)

    print(score)


if __name__ == "__main__":
    main()
