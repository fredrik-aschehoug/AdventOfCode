from common import fileToList, loadFile

def getInbetween(prev, inc, pos, op):
  res = list()
  prev0 = prev[0]
  prev1 = prev[1]

  if pos == 0 and op == "+":
    for i in range(inc):
      prev0 += 1
      res.append((prev0, prev1))
  if pos == 0 and op == "-":
    for i in range(inc):
      prev0 -= 1
      res.append((prev0, prev1))
  if pos == 1 and op == "+":
    for i in range(inc):
      prev1 += 1
      res.append((prev0, prev1))
  if pos == 1 and op == "-":
    for i in range(inc):
      prev1 -= 1
      res.append((prev0, prev1))
  return res

def getTouples(prev, inst):
  """
    Return coordinate (x, y)
    U = increase Y
    D = decrease Y

    R = increase X
    L = decrease X
  """
  res = None
  if inst[0] is "U":
    res = getInbetween(prev, int(inst[1:]), 1, "+")
  if inst[0] is "D":
    res = getInbetween(prev, int(inst[1:]), 1, "-")
  if inst[0] is "R":
    res = getInbetween(prev, int(inst[1:]), 0, "+")
  if inst[0] is "L":
    res = getInbetween(prev, int(inst[1:]), 0, "-")
  return res


def getCoordinates(instuctions):
  pos = 0
  coordinates = list()

  for item in instuctions:
    if pos == 0:
      coordinates.extend(getTouples((0, 0), item))
      pos += 1
      continue
    
    coordinates.extend(getTouples(coordinates[-1], item))
    pos += 1

  return coordinates


def findIntersections(l1, l2):
  res = list()
  for cord in l1:
    if cord in l2:
      res.append(cord)
  return res


def getClosestIntersection(l):
  distances = [abs(x) + abs(y) for x, y in l]
  return min(distances)

def main():
  fh = loadFile("03/input.txt")
  content = fh.read()
  lines = content.split("\n")

  path1 = lines[0].split(",")
  path2 = lines[1].split(",")

  cord1 = getCoordinates(path1)
  cord2 = getCoordinates(path2)
  intersections = findIntersections(cord1, cord2)

  print(getClosestIntersection(intersections))

if __name__ == "__main__":
    main()