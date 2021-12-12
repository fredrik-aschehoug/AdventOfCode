def get_network(lines, part2=False):
    paths = dict()
    for line in lines:
        start, stop = line.split("-")
        if (not (part2 and stop == "start")):
            paths.setdefault(start, []).append(stop)
        if (part2 and stop == "end"):
            continue
        if (start != "start"):
            paths.setdefault(stop, []).append(start)
    
    if(part2):
        paths["end"] = []
    return paths
