from queue import PriorityQueue
import numpy as np


class Searcher:
    def __init__(self, matrix):
        self.matrix = matrix
        self.set_bounds()

    def set_bounds(self):
        self.row_bounds = range(self.matrix.shape[0])
        self.col_bounds = range(self.matrix.shape[1])

    def check_bounds(self, r, c):
        if(r not in self.row_bounds):
            return False
        if(c not in self.col_bounds):
            return False
        return True

    def get_neighbor_indices(self, position):
        r, c = position
        indices = [
            (r - 1, c),
            (r, c - 1), (r, c + 1),
            (r + 1, c)
        ]
        return indices

    def get_neighbors(self, node):
        neighbors = list()
        indices = self.get_neighbor_indices(node)

        for r, c in indices:
            if (self.check_bounds(r, c)):
                neighbors.append((r, c))
        return neighbors

    def get_shortest_path(self):
        # Run dijkstras search to find path
        shortest_distances = {node: float('inf') for node in np.ndindex(self.matrix.shape)}
        visited = list()
        start_node = (0, 0)
        shortest_distances[start_node] = 0
        frontier = PriorityQueue()
        frontier.put((0, start_node))

        while not frontier.empty():
            (dist, current_node) = frontier.get()
            visited.append(current_node)

            for neighbor in self.get_neighbors(current_node):
                if neighbor not in visited:
                    (r, c) = neighbor
                    current_risk = shortest_distances[neighbor]
                    new_risk = self.matrix[r][c] + shortest_distances[current_node]
                    if new_risk < current_risk:
                        frontier.put((new_risk, neighbor))
                        shortest_distances[neighbor] = new_risk

        goal_row = self.matrix.shape[0] - 1
        goal_col = self.matrix.shape[1] - 1
        goal_position = (goal_row, goal_col)

        return shortest_distances[goal_position]
