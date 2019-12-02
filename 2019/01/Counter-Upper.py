import math

def loadFile(fileName):
    """Return file handle if file exists. 
    In case of exception, return None"""
    try:
        fileHandle = open(fileName, encoding="UTF-8")
        fileValid = True
    except:
        fileValid = False
    if fileValid:
        return fileHandle
    else:
        return None

def fileToList(fh):
    content = fh.read()
    contentList = content.split("\n")
    return list(map(int, contentList))

def calculateFuel(mass):
    return math.floor(mass / 3) - 2


def main():
  inputHandle = loadFile("01/input.txt")
  massList = fileToList(inputHandle)
  fuelList = list()

  for mass in massList:
      fuelList.append(calculateFuel(mass))

  totalFuel = 0
  for fuel in fuelList:
    totalFuel += fuel
  print(totalFuel)

if __name__ == "__main__":
    main()