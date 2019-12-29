def loadFile(fileName):
    """Return file handle if file exists. 
    In case of exception, return None"""
    try:
        fileHandle = open(fileName, encoding="UTF-8")
        fileValid = True
    except:
        fileValid = False
    if fileValid:
        return fileHandle
    else:
        return None


def fileToList(fh, delimiter):
    content = fh.read()
    return content.split(delimiter)


def fileToIntList(fh, delimiter):
    content = fh.read()
    contentList = content.split(delimiter)
    return list(map(int, contentList))


def listToString(l):
    return ''.join(map(str, l))

def chunks(l, n):
    """Split a list into n-sized chunks"""
    for i in range(0, len(l), n):
        yield l[i:i + n]

def parseIntCode(fh):
    l = fileToIntList(fh, ",")
    res = dict()
    for i, item in enumerate(l):
        res[i] = item
    return res