from utils import fileToList


def main():
    with open("01/input.txt", encoding="UTF-8") as file:
        measurements = fileToList(file, "\n")
    previousMeasurement = measurements[0]
    counter = 0

    for measurement in measurements:
        if measurement > previousMeasurement:
            counter += 1
        previousMeasurement = measurement

    print(counter)


if __name__ == "__main__":
    main()
