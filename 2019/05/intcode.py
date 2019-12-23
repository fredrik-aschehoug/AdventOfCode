from common import listToString


def getArgs(arg1, arg2, arr, mode1, mode2):
    if mode1 and mode2:
        res1, res2, = arg1, arg2
    elif mode1:
        res1, res2 = arg1, arr[arg2]
    elif mode2:
        res1, res2 = arr[arg1], arg2
    else:
        res1, res2 = arr[arg1], arr[arg2]

    return res1, res2


def op1(arg1, arg2, resPos, arr, mode1, mode2):
    # Add
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2)
    arr[resPos] = param1 + param2


def op2(arg1, arg2, resPos, arr, mode1, mode2):
    # Multiply
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2)
    arr[resPos] = param1 * param2
    

def op3(val, pos, arr):
    # Write input to position
    arr[pos] = val


def op4(pos, arr, immediateMode):
    # Output value in position
    if immediateMode:
        print(pos)
    else:
        print(arr[pos])


def op5(arg1, arg2, arr, mode1, mode2):
    # jump-if-true
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2)
    if param1 != 0:
        return param2
    return None


def op6(arg1, arg2, arr, mode1, mode2):
    # jump-if-false
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2)
    if param1 == 0:
        return param2
    return None

def op7(arg1, arg2, resPos, arr, mode1, mode2):
    # less than
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2)
    if param1 < param2:
        arr[resPos] = 1
    else:
        arr[resPos] = 0


def op8(arg1, arg2, resPos, arr, mode1, mode2):
    # equals
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2)
    if param1 == param2:
        arr[resPos] = 1
    else:
        arr[resPos] = 0



def parseInstruction(instruction):
    parsed = {
        "m1": 0,
        "m2": 0,
        "m3": 0
    }
    instructionList = list(instruction)
    instructionLenght = len(instructionList)

    if instructionLenght == 1:
        parsed["opCode"] = int(instruction)
        return parsed

    opCode = listToString(instructionList[-2:])
    parsed["opCode"] = int(opCode)

    # Remove last two digits and reverse
    modes = instructionList[:-2][::-1]

    for i, mode in enumerate(modes):
        parsed["m{}".format(i + 1)] = int(mode)

    return parsed


def run(inputValue, data):
    program = data.copy()
    pos = 0
    newPos = None  # for storing positions given by op5 and op6

    while True:
        instruction = parseInstruction(str(program[pos]))
        if instruction["opCode"] == 99:
            break
        if instruction["opCode"] == 1:
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
            op4(program[pos + 1], program, instruction["m1"])
            posIncrement = 2
        elif instruction["opCode"] == 5:
            newPos = op5(program[pos + 1], program[pos + 2],
                         program, instruction["m1"], instruction["m2"])
            if newPos is None: posIncrement = 3
        elif instruction["opCode"] == 6:
            newPos = op6(program[pos + 1], program[pos + 2],
                         program, instruction["m1"], instruction["m2"])
            if newPos is None: posIncrement = 3
        elif instruction["opCode"] == 7:
            op7(program[pos + 1], program[pos + 2],
                program[pos + 3], program, instruction["m1"], instruction["m2"])
            posIncrement = 4
        elif instruction["opCode"] == 8:
            op8(program[pos + 1], program[pos + 2],
                program[pos + 3], program, instruction["m1"], instruction["m2"])
            posIncrement = 4
        else:
            print("error, unknown operation")
            print(pos)
            print(program[pos])
            break

        if newPos is not None:
            pos = newPos
            newPos = None
        else:
            pos += posIncrement
