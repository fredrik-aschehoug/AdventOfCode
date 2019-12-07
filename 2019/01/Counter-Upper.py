from common import loadFile, fileToList, calculateFuel


def main():
  inputHandle = loadFile("01/input.txt")
  massList = fileToList(inputHandle, "\n")
  fuelList = list()

  for mass in massList:
      fuelList.append(calculateFuel(mass))

  totalFuel = 0
  for fuel in fuelList:
    totalFuel += fuel
  
  print(totalFuel)

if __name__ == "__main__":
    main()