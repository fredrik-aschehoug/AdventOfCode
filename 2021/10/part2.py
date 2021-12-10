import math


character_map = {
    ")": "(",
    "]": "[",
    "}": "{",
    ">": "<"
}

points_map = {
    "(": 1,
    "[": 2,
    "{": 3,
    "<": 4
}


def check_line(line):
    stack = list()
    score = 0
    for character in line:
        if (character in character_map.values()):
            stack.append(character)
            continue
        if (character_map[character] != stack[-1]):
            return 0
        if (character_map[character] == stack[-1]):
            stack.pop()
            continue

    stack.reverse()
    for character in stack:
        score = score * 5
        score += points_map[character]
    return score


def main():
    with open("10/input.txt", encoding="UTF-8") as file:
        lines = file.read().splitlines()

    scores = list()
    for line in lines:
        scores.append(check_line(line))

    scores = [score for score in scores if score > 0]
    scores.sort()
    middle_index = math.floor((len(scores) - 1) / 2)
    middle = scores[middle_index]
    print(middle)


if __name__ == "__main__":
    main()
