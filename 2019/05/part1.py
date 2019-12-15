import intcode
from common import *


def main():
    inputVal = 1
    inputHandle = loadFile("05/input.txt")
    program = fileToList(inputHandle, ",")

    # output = intcode.run(program, inputVal)
    intcode.run(inputVal, program)

    # fout = open('05/output.txt', 'w')
    # fout.write(str(output))


if __name__ == "__main__":
    main()
