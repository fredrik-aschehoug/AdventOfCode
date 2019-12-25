import intcode
from common import loadFile, fileToIntList
from itertools import permutations


def runPermutation(program, permutation):
    signal = 0
    for value in permutation:
        signal = intcode.run(value, signal, program)

    return signal


def main():
    inputHandle = loadFile("07/input.txt")
    program = fileToIntList(inputHandle, ",")

    phaseSettings = list(permutations([0, 1, 2, 3, 4], 5))

    highestSignal = 0

    for phaseSetting in phaseSettings:
        currentSignal = runPermutation(program, phaseSetting)

        if currentSignal > highestSignal:
            highestSignal = currentSignal

    print(highestSignal)


if __name__ == "__main__":
    main()
