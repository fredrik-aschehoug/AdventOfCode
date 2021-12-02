def main():
    with open("02/input.txt", encoding="UTF-8") as file:
        content = file.read()
    lines = content.split("\n")
    splitLines = [line.split() for line in lines]
    operations = [(op, int(val)) for op, val in splitLines]

    horizontal = 0
    depth = 0
    aim = 0

    for operation in operations:
        op, val = operation
        if (op == "forward"):
            horizontal += val
            if (aim > 0):
                depth += aim * val
        if (op == "up"):
            aim -= val
        if (op == "down"):
            aim += val

    result = horizontal * depth
    print(result)


if __name__ == "__main__":
    main()
