import re
import math
import json


def add_left(number, i):
    digit = number[i]
    if number[i + 1].isdigit():
        digit = f"{digit}{number[i + 1]}"
    for j in range(i - 1, 0, -1):
        if number[j].isdigit():
            if number[j - 1].isdigit():
                new_digit = str(int(number[j - 1] + number[j]) + int(digit))
                number = number[:j - 1] + new_digit + number[j + 1:]
            else:
                new_digit = str(int(number[j]) + int(digit))
                number = number[:j] + new_digit + number[j + 1:]
            return number
    return number


def add_right(number, i):
    i = i if number[i + 2].isdigit() else i + 1
    digit = number[i + 2]
    if number[i + 3].isdigit():
        digit = f"{digit}{number[i + 3]}"
    for j in range(i + 2 + len(digit), len(number)):
        if number[j].isdigit():
            if number[j + 1].isdigit():
                new_digit = str(int(number[j] + number[j + 1]) + int(digit))
                number = number[:j] + new_digit + number[j + 2:]
            else:
                new_digit = str(int(number[j]) + int(digit))
                number = number[:j] + new_digit + number[j + 1:]
            return number
    return number


def explode(number):
    level = 0
    i = 0
    for c in number:
        if level == 5:
            length = len(number)
            number = add_left(number, i)

            i += len(number) - length
            number = add_right(number, i)
            offset = 3
            while True:
                if number[i + offset] == "]":
                    break
                offset += 1
            number = f"{number[:i - 1]}0{number[i + offset + 1:]}"
            return number

        if c == "[":
            level += 1
        elif c == "]":
            level -= 1
        i += 1


def split(number):
    match = re.search(r"[0-9]{2}", number)
    if match is None:
        return number
    i = match.start()
    digit = int(number[i:i + 2])
    pair = math.floor(digit / 2), math.ceil(digit / 2)
    number = f"{number[:i]}[{pair[0]},{pair[1]}]{number[i + 2:]}"
    return number


def reduce(number):
    while True:
        old_number = number
        exploded = explode(number)
        if exploded:
            number = exploded
            continue
        number = split(number)
        if number == old_number:
            return number


def get_magnitude(number: list):
    if type(number) == int:
        return number
    if type(number[0]) == int:
        return (number[0] * 3) + (number[-1] * 2)
    return (get_magnitude(number[0]) * 3) + (get_magnitude(number[-1]) * 2)


def main():
    with open("18/input.txt", encoding="UTF-8") as file:
        lines = file.read().splitlines()

    result = ""
    for i, line in enumerate(lines):
        if i == 0:
            result = line
            continue
        result = f"[{result},{line}]"
        result = reduce(result)

    magnitude = get_magnitude(json.loads(result))
    print("Magnitude: ", magnitude)


if __name__ == "__main__":
    main()
