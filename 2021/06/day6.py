import numpy as np


def calculate_school_size(input_text, days):
    bincount = np.bincount([int(x) for x in input_text.split(",")])
    school = {i: 0 for i in range(10)}
    for number, count in enumerate(bincount):
        school[number] = count

    for day in range(days):
        spawners = school[0]
        for i in range(max(school)):
            school[i] = school.get(i + 1, 0)
        school[6] = school.get(6, 0) + spawners
        school[8] = school.get(8, 0) + spawners

    count = sum(school.values())
    return count


def main():
    with open("06/input.txt", encoding="UTF-8") as file:
        content = file.read()

    part1_result = calculate_school_size(content, 80)
    print("Part 1: {}".format(part1_result))

    part2_result = calculate_school_size(content, 256)
    print("Part 2: {}".format(part2_result))


if __name__ == "__main__":
    main()
