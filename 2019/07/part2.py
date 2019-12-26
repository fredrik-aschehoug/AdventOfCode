import intcode2
from common import loadFile, fileToIntList
from itertools import permutations


def runPermutation(program, permutation):
    signal = 0
    firstRun = True
    # state for each amp/digit in permutation
    state = dict()
    for value in permutation:
        state[value] = {"state": 0, "program": program}
    
    while True:
        for value in permutation:
            if firstRun:
                inputValue = value
            else:
                inputValue = None
            
            signal, state[value]["program"], state[value]["state"] = intcode2.run(inputValue, signal, state[value]["program"], state[value]["state"])
            state[value]["signal"] = signal
        if state[value]["state"] is None:
            return state[permutation[-1]]["signal"]
        firstRun = False


def main():
    inputHandle = loadFile("07/input.txt")
    program = fileToIntList(inputHandle, ",")

    phaseSettings = list(permutations([5, 6, 7, 8, 9], 5))

    highestSignal = 0

    for phaseSetting in phaseSettings:
        currentSignal = runPermutation(program, phaseSetting)

        if currentSignal > highestSignal:
            highestSignal = currentSignal

    print(highestSignal)


if __name__ == "__main__":
    main()
