def get_network(lines):
    paths = dict()
    for line in lines:
        start, stop = line.split("-")
        paths.setdefault(start, []).append(stop)

        if (start != "start"):
            paths.setdefault(stop, []).append(start)
    return paths
