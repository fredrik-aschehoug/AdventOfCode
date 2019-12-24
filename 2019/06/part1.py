from common import loadFile, fileToList
import networkx as nx
import matplotlib.pyplot as plt


def main():
    inputHandle = loadFile("06/input.txt")
    inputList = fileToList(inputHandle, "\n")

    orbits = [x.split(")") for x in inputList]

    g = nx.DiGraph()

    for a, b in orbits:
        g.add_edge(b, a)

    paths = nx.shortest_path(g)

    l1 = list()
    for item in paths.values():
        for x in item.values():
            if len(x) > 1:
                l1.append(x)

    print(len(l1))


if __name__ == "__main__":
    main()
