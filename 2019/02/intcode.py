from common import *
    
def op1(pos1, pos2, pos3, arr):
  # Add
  arr[pos3] = arr[pos1] + arr[pos2]

def op2(pos1, pos2, pos3, arr):
  # Multiply
  arr[pos3] = arr[pos1] * arr[pos2]

def run(noun, verb, data):
  codes = data.copy()
  codes[1] = noun
  codes[2] = verb
  pos = 0

  while True:
    if codes[pos] == 99:
      break
    if codes[pos] == 1:
      op1(codes[pos + 1], codes[pos + 2], codes[pos + 3], codes)
    elif codes[pos] == 2:
      op2(codes[pos + 1], codes[pos + 2], codes[pos + 3], codes)
    else:
      print("error, unknown operation")
      print(codes[pos])
      break
    pos += 4
  return codes[0]

def main():
  inputHandle = loadFile("02/input.txt")
  opList = fileToList(inputHandle, ",")

  res = run(12, 2, opList)

  fout = open('02/output.txt', 'w')
  fout.write(str(res))

if __name__ == "__main__":
    main()