import intcode
from common import loadFile, parseIntCode


def main():
    inputVal = 1
    inputHandle = loadFile("09/input.txt")
    program = parseIntCode(inputHandle)

    intcode.run(inputVal, program)

if __name__ == "__main__":
    main()
