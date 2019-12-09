
    
def op1(pos1, pos2, pos3, arr):
  # Add
  arr[pos3] = arr[pos1] + arr[pos2]

def op2(pos1, pos2, pos3, arr):
  # Multiply
  arr[pos3] = arr[pos1] * arr[pos2]

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
    parsed.opCode = int(instruction)
    return parsed
  
  parsed.opCode = int(instructionList[-1])
  modes = instructionList[:-2].reverse()

  for i, mode in enumerate(modes):
    parsed["m{}".format(i)] = mode
  
  return parsed

def run(inputValue, data):
  program = data.copy()
  pos = 0
  instruction = parseInstruction(program[0])
  output = None

  while True:
    if program[pos] == 99:
      break
    if program[pos] == 1:
      operation = op1
      posIncrement = 4
    elif program[pos] == 2:
      operation = op2
      posIncrement = 4
    elif program[pos] == 3:
      operation = op3
      posIncrement = 2
    elif program[pos] == 4:
      operation = op4
      posIncrement = 2
    else:
      print("error, unknown operation")
      print(program[pos])
      break
    
    operation(program[pos + 1], program[pos + 2], program[pos + 3], program)
    pos += posIncrement
  return output