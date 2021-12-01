from utils import loadFile, fileToList


def main():
    inputHandle = loadFile("01/input.txt")
    measurements = fileToList(inputHandle, "\n")
    previousMeasurement = measurements[0]
    counter = 0

    for measurement in measurements:
        if measurement > previousMeasurement:
            counter += 1
        previousMeasurement = measurement

    print(counter)


if __name__ == "__main__":
    main()
