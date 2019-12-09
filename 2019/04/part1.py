def isDecreasing(num):
  for i, item in enumerate(num):
    if i == 0: continue
    if item < num[i - 1]:
      return False
  return True


def hasDouble(num):
  for i, item in enumerate(num):
    if i + 1 == len(num): return False
    if item == num[i + 1]: return True
  return False


def main():
  numberRange = range(134564, 585159)
  res1 = [x for x in numberRange if isDecreasing(str(x))]
  res2 = [x for x in res1 if hasDouble(str(x))]

  print(len(res2))

if __name__ == "__main__":
    main()