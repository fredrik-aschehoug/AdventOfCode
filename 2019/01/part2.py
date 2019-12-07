from common import loadFile, fileToList, calculateFuel
import math


def calculateFuel2(mass):
    fuel = math.floor(mass / 3) - 2
    if fuel <= 0:
      return 0
    return fuel + calculateFuel2(fuel)

def main():
  inputHandle = loadFile("01/input.txt")
  massList = fileToList(inputHandle, "\n")
  fuelList = list()

  totalFuel = sum([calculateFuel2(mass) for mass in massList])
  
  print(totalFuel)

if __name__ == "__main__":
    main()