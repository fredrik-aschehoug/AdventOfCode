def fileToList(fh, delimiter):
    content = fh.read()
    contentList = content.split(delimiter)
    return list(map(int, contentList))
