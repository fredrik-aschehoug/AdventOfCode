from common import loadFile, fileToList
import networkx as nx


def main():
    inputHandle = loadFile("06/input.txt")
    inputList = fileToList(inputHandle, "\n")

    orbits = [x.split(")") for x in inputList]

    g = nx.Graph()

    for a, b in orbits:
        g.add_edge(b, a)

    path = nx.shortest_path_length(g, source="H4S", target="NRN")

    print(path)


if __name__ == "__main__":
    main()
