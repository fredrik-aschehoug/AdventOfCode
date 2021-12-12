from copy import deepcopy


class PathFinder:
    def __init__(self, network):
        self.network = network

    @staticmethod
    def is_small_cave(name):
        return name.islower()

    def is_valid_next_step(self, path, node):
        if (self.is_small_cave(node)):
            if (node in path):
                return False
        return True

    def add_move(self, path, node):
        new_path = deepcopy(path)
        new_path.append(node)
        return new_path

    def get_paths(self, neighbors, path):
        new_paths = list()

        for node in neighbors:
            if (self.is_valid_next_step(path, node)):
                new_path = self.add_move(path, node)
                new_paths.append(new_path)
        return new_paths

    def get_distinct_paths(self):
        # Run BFS to find paths
        paths = list()
        frontier = list()
        frontier.append(["start"])

        while (len(frontier) > 0):
            path = frontier.pop(0)
            last_node = path[-1]
            if (last_node == "end"):
                paths.append(path)
                continue

            neighbors = self.network[last_node]
            new_paths = self.get_paths(neighbors, path)
            frontier.extend(new_paths)
        return paths
