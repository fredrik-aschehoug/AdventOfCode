from utils import fileToList


def main():
    with open("01/input.txt", encoding="UTF-8") as file:
        measurements = fileToList(file, "\n")
    previousMeasurement = sum(measurements[0:3])
    counter = 0

    for i in range(len(measurements)):
        if (i + 2 > len(measurements)):
            break
        window = measurements[i:i + 3]
        measurement = sum(window)
        if measurement > previousMeasurement:
            counter += 1
        previousMeasurement = measurement

    print(counter)


if __name__ == "__main__":
    main()
