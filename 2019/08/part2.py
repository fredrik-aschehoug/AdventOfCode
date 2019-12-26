from common import loadFile, chunks
from PIL import Image


def main():
    inputHandle = loadFile("08/input.txt")
    content = inputHandle.read()
    inputList = list(content)
    inputIntList = list(map(int, inputList))

    horizontalChunks = list(chunks(inputIntList, 25))
    layerChunks = list(chunks(horizontalChunks, 6))
    layerChunks.reverse()

    # Flatten image
    imageValues = None
    for i, layer in enumerate(layerChunks):
        if i == 0:
            imageValues = layer
            continue
        for ii, row in enumerate(layer):
            for iii, digit in enumerate(row):
                if digit != 2:
                    imageValues[ii][iii] = digit

    # Convert to RGBa
    for ii, row in enumerate(imageValues):
        for iii, digit in enumerate(row):
            if digit == 0:  # Black
                imageValues[ii][iii] = (0, 0, 0, 255)
            if digit == 1:  # White
                imageValues[ii][iii] = (255, 255, 255, 255)
            if digit == 2:  # Transparent
                imageValues[ii][iii] = (0, 0, 0, 0)

    flattened = [val for sublist in imageValues for val in sublist]
    img = Image.new("RGBA", (25, 6))
    img.putdata(flattened)
    img.show()


if __name__ == "__main__":
    main()
