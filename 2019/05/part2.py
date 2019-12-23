import intcode
from common import loadFile, fileToList


def main():
    inputVal = 5
    inputHandle = loadFile("05/input.txt")
    program = fileToList(inputHandle, ",")


    intcode.run(inputVal, program)

if __name__ == "__main__":
    main()
