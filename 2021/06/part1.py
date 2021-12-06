import numpy as np


def main():
    with open("06/input.txt", encoding="UTF-8") as file:
        content = file.read()

    school = np.asarray([int(x) for x in content.split(",")], dtype="i")
    days = 80

    for day in range(days):
        school = np.asarray([fish - 1 for fish in school], dtype="i")
        spawners = school[school < 0]
        rest = school[school >= 0]
        school = np.concatenate((rest, np.full(len(spawners), 6), np.full(len(spawners), 8)))

    result = len(school)
    print(result)


if __name__ == "__main__":
    main()
