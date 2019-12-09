def isDecreasing(num):
  for i, item in enumerate(num):
    if i == 0: continue
    if item < num[i - 1]:
      return False
  return True


def hasDouble(num):
  isDouble = False
  i = 0
  while i <= len(num):
    # if 2 consecutive
    if i + 1 < len(num) and num[i] == num[i + 1]:
      # if 4 consecutive
      if i + 3 < len(num) and num[i] == num[i + 3] and num[i] == num[i + 2]:
        i += 4
        continue
      # if 3 consecutive
      if i + 2 < len(num) and num[i] == num[i + 2]:
        i += 3
        continue
      isDouble = True
      i += 2
    i += 1
  return isDouble

def sameDigits(num):
  prev = num[0]
  for digit in num:
    if digit == prev: continue
    else: return False
  return True


def main():
  numberRange = range(134564, 585159)
  res1 = [x for x in numberRange if isDecreasing(str(x))]
  res2 = [x for x in res1 if hasDouble(str(x))]
  res3 = [x for x in res2 if not sameDigits(str(x))]

  print(len(res3))

if __name__ == "__main__":
    main()