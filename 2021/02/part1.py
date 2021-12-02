def main():
    with open("02/input.txt", encoding="UTF-8") as file:
        content = file.read()
    lines = content.split("\n")
    splitLines = [line.split() for line in lines]
    operations = [(op, int(val)) for op, val in splitLines]

    horizontal = 0
    depth = 0

    for operation in operations:
        op, val = operation
        if (op == "forward"):
            horizontal += val
        if (op == "up"):
            depth -= val
        if (op == "down"):
            depth += val

    result = horizontal * depth
    print(result)


if __name__ == "__main__":
    main()
