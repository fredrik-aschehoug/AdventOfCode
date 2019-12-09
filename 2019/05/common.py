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
    contentList = content.split(delimiter)
    return list(map(int, contentList))