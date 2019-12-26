from common import loadFile, fileToIntList, chunks
from itertools import permutations

def main():
    inputHandle = loadFile("08/input.txt")
    content = inputHandle.read()
    inputList = list(content)
    inputIntList = list(map(int, inputList))

    horizontalChunks = list(chunks(inputIntList, 25))
    layerChunks = list(chunks(horizontalChunks, 6))

    leastZeros = None
    leastZerosIndex = None
    for lIndex, layer in enumerate(layerChunks):
        zeroCount = 0
        for line in layer:
            zeroCount += line.count(0)
        if leastZeros is None:
            leastZeros = zeroCount
            leastZerosIndex = lIndex
            continue
        if zeroCount < leastZeros:
            leastZeros = zeroCount
            leastZerosIndex = lIndex
    
    ones = 0
    twos = 0
    for line in layerChunks[leastZerosIndex]:
        ones += line.count(1)
        twos += line.count(2)
    print(ones * twos)





if __name__ == "__main__":
    main()
