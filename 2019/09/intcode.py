from common import listToString

def checkMem(arr, args):
    for arg in args:
        if arr.get(arg) is None:
            arr[arg] = 0


def getArg(arg, mode, relBase, arr):
    checkMem(arr, [arg, relBase + arg])
    res = {
        0: arr[arg],
        1: arg,
        2: arr[relBase + arg]
    }
    return res[mode]


def getResPos(arg, mode, relBase):
    res = {
        0: arg,
        2: relBase + arg
    }
    return res[mode]


def getArgs(arg1, arg2, arr, mode1, mode2, relBase):
    checkMem(arr,[arg1, relBase + arg1, arg2, relBase + arg2] )
    res = {
        "res1": {
            0: arr[arg1],
            1: arg1,
            2: arr[relBase + arg1]
        },
        "res2": {
            0: arr[arg2],
            1: arg2,
            2: arr[relBase + arg2]
        }
    }
    return res["res1"][mode1], res["res2"][mode2]


def op1(arg1, arg2, arg3, arr, mode1, mode2, mode3, relBase):
    """Add"""
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2, relBase)
    resPos = getResPos(arg3, mode3, relBase)
    arr[resPos] = param1 + param2


def op2(arg1, arg2, arg3, arr, mode1, mode2, mode3, relBase):
    """Multiply"""
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2, relBase)
    resPos = getResPos(arg3, mode3, relBase)
    arr[resPos] = param1 * param2
    

def op3(val, pos, arr, mode, relBase):
    """Write input to position"""
    if mode == 0:
        arr[pos] = val
    if mode == 2:
        arr[relBase + pos] = val


def op4(pos, arr, mode, relBase):
    """Output value in position"""
    param = getArg(pos, mode, relBase, arr)
    print(param)


def op5(arg1, arg2, arr, mode1, mode2, relBase):
    """Jump-if-true"""
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2, relBase)
    if param1 != 0:
        return param2
    return None


def op6(arg1, arg2, arr, mode1, mode2, relBase):
    """Jump-if-false"""
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2, relBase)
    if param1 == 0:
        return param2
    return None

def op7(arg1, arg2, arg3, arr, mode1, mode2, mode3, relBase):
    """Less than"""
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2, relBase)
    resPos = getResPos(arg3, mode3, relBase)
    if param1 < param2:
        arr[resPos] = 1
    else:
        arr[resPos] = 0


def op8(arg1, arg2, arg3, arr, mode1, mode2, mode3, relBase):
    """Equals"""
    param1, param2 = getArgs(arg1, arg2, arr, mode1, mode2, relBase)
    resPos = getResPos(arg3, mode3, relBase)
    if param1 == param2:
        arr[resPos] = 1
    else:
        arr[resPos] = 0


def op9(arg, mode, relBase, arr):
    """Adjust relative base"""
    param = getArg(arg, mode, relBase, arr)
    return relBase + param



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
    relPos = 0

    while True:
        instruction = parseInstruction(str(program[pos]))
        if instruction["opCode"] == 99:
            break
        if instruction["opCode"] == 1:
            op1(program[pos + 1], program[pos + 2],
                program[pos + 3], program, instruction["m1"], instruction["m2"], instruction["m3"], relPos)
            posIncrement = 4
        elif instruction["opCode"] == 2:
            op2(program[pos + 1], program[pos + 2],
                program[pos + 3], program, instruction["m1"], instruction["m2"], instruction["m3"], relPos)
            posIncrement = 4
        elif instruction["opCode"] == 3:
            op3(inputValue, program[pos + 1], program, instruction["m1"], relPos)
            posIncrement = 2
        elif instruction["opCode"] == 4:
            op4(program[pos + 1], program, instruction["m1"], relPos)
            posIncrement = 2
        elif instruction["opCode"] == 5:
            newPos = op5(program[pos + 1], program[pos + 2],
                         program, instruction["m1"], instruction["m2"], relPos)
            if newPos is None: posIncrement = 3
        elif instruction["opCode"] == 6:
            newPos = op6(program[pos + 1], program[pos + 2],
                         program, instruction["m1"], instruction["m2"], relPos)
            if newPos is None: posIncrement = 3
        elif instruction["opCode"] == 7:
            op7(program[pos + 1], program[pos + 2],
                program[pos + 3], program, instruction["m1"], instruction["m2"], instruction["m3"], relPos)
            posIncrement = 4
        elif instruction["opCode"] == 8:
            op8(program[pos + 1], program[pos + 2],
                program[pos + 3], program, instruction["m1"], instruction["m2"], instruction["m3"], relPos)
            posIncrement = 4
        elif instruction["opCode"] == 9:
            relPos = op9(program[pos + 1], instruction["m1"], relPos, program)
            posIncrement = 2
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
