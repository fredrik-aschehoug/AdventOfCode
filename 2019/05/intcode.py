

def op1(arg1, arg2, resPos, arr, mode1, mode2):
    # Add
    if mode1 and mode2:
        arr[resPos] = arg1 + arg2
    elif mode1:
        arr[resPos] = arg1 + arr[arg2]
    elif mode2:
        arr[resPos] = arr[arg1] + arg2
    else:
        arr[resPos] = arr[arg1] + arr[arg2]


def op2(arg1, arg2, resPos, arr, mode1, mode2):
    # Multiply
    if mode1 and mode2:
        arr[resPos] = arg1 * arg2
    elif mode1:
        arr[resPos] = arg1 * arr[arg2]
    elif mode2:
        arr[resPos] = arr[arg1] * arg2
    else:
        arr[resPos] = arr[arg1] * arr[arg2]


def op3(val, pos, arr):
    # Write input to position
    arr[pos] = val


def op4(pos, arr):
    # Output value in position
    print(arr[pos])


def parseInstruction(instruction):
    parsed = {
        "m1": 0,
        "m2": 0,
        "m3": 0,
        "m4": 0
    }
    instructionList = list(instruction)
    instructionLenght = len(instructionList)

    if instructionLenght == 1:
        parsed["opCode"] = int(instruction)
        return parsed

    parsed["opCode"] = int(instructionList[-1])
    # Remove last two digits and reverse
    modes = instructionList[:-2][::-1]

    print(instructionList[:-2])
    print(modes)
    print("---------")
    for i, mode in enumerate(modes):
        parsed["m{}".format(i)] = mode

    return parsed


def run(inputValue, data):
    program = data.copy()
    pos = 0

    while True:
        instruction = parseInstruction(str(program[pos]))
        if instruction["opCode"] == 99:
            break
        if instruction["opCode"] == 1:
            print("m1: {}, m2: {}".format(
                instruction["m1"], instruction["m2"]))
            op1(program[pos + 1], program[pos + 2],
                program[pos + 3], program, instruction["m1"], instruction["m2"])
            posIncrement = 4
        elif instruction["opCode"] == 2:
            op2(program[pos + 1], program[pos + 2],
                program[pos + 3], program, instruction["m1"], instruction["m2"])
            posIncrement = 4
        elif instruction["opCode"] == 3:
            op3(inputValue, program[pos + 1], program)
            posIncrement = 2
        elif instruction["opCode"] == 4:
            op4(program[pos + 1], program)
            posIncrement = 2
        else:
            print("error, unknown operation")
            print(program[pos])
            break

        pos += posIncrement
