from common import loadFile, fileToList
import networkx as nx
import matplotlib.pyplot as plt




def main():
    inputHandle = loadFile("06/input.txt")
    inputList = fileToList(inputHandle, "\n")
    orbits = list()
    
    g = nx.DiGraph()

    for item in inputList:
        orbits.append(item.split(")"))

    print("creating graph")
    for a, b in orbits:
        #print("{} orbits {}".format(b,a))
        g.add_edge(b, a)

    #nx.draw(g, with_labels=True)
    #plt.show()

    print("getting all paths")

    allPaths = dict(nx.all_pairs_shortest_path(g))
    pathList = set()

    print("Get all shortests paths")

    # Find all shortest paths in graph and add to list
    for key in allPaths:
        for path in allPaths[key]:
            pathList.add(tuple(allPaths[key][path]))
    
    print("remove subsets")
    print(len(pathList))
    #remove subsets
    noSubsets = pathList.copy()
    for m in pathList:
        for n in pathList:
            if set(m).issubset(set(n)) and m != n:
                noSubsets.remove(m)
                break
    
    print("reversing lists")

    for l in noSubsets:
        l.reverse()

  
    print("find longest list")
    
    # find longest list
    longestList = None
    longestSoFar = 0

    for l in noSubsets:
        if len(l) > longestSoFar:
            longestList = l
            longestSoFar = len(l)
            
    noSubsets.remove(longestList)

    count = 0
    # count
    print("counting")

    for i in range(1, len(longestList)):
        count += i
    for l in noSubsets:
        rang = [x for x in range(1, len(l))]
        rang.reverse()
        for i in rang:
            if l[i] not in longestList:
                count += i

    print(count)



if __name__ == "__main__":
    main()
