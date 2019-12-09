from common import loadFile, fileToList, calculateFuel


def main():
  inputHandle = loadFile("01/input.txt")
  massList = fileToList(inputHandle, "\n")

  totalFuel = sum([calculateFuel(mass) for mass in massList])
  
  print(totalFuel)

if __name__ == "__main__":
    main()