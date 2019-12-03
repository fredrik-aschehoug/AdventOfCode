
from itertools import product
from common import *
from intcode import run

def main():
  inputHandle = loadFile("02/input.txt")
  opList = fileToList(inputHandle, ",")

  for noun, verb in product(range(0, 100), range(0, 100)):
    if run(noun, verb, opList) == 19690720:
      print( (100 * noun) + verb)
      break


if __name__ == "__main__":
    main()