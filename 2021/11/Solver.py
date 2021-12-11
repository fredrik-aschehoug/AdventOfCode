import numpy as np


class SolverBase:
    def __init__(self, file_content):
        self.flashes = 0
        self.matrix = self.get_matrix(file_content)
        self.set_bounds()

    @staticmethod
    def get_matrix(file_content):
        columns = len(file_content.split("\n")[0])
        energy_levels = [int(level) for level in list(file_content.replace("\n", ""))]
        matrix = np.array(energy_levels).reshape(-1, columns)
        return matrix

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
            (r - 1, c - 1), (r - 1, c), (r - 1, c + 1),
            (r, c - 1), (r, c + 1),
            (r + 1, c - 1), (r + 1, c), (r + 1, c + 1)
        ]
        return indices

    @staticmethod
    def increase_energy(matrix):
        incrementer = lambda x: x + 1
        vfunc = np.vectorize(incrementer)
        return vfunc(matrix)

    def get_flashers(self):
        flashers = np.where(self.matrix > 9)
        return list(zip(flashers[0], flashers[1]))

    def handle_flashes(self):
        frontier = self.get_flashers()
        flashed = list()

        while len(frontier) > 0:
            current = frontier.pop()
            if (current in flashed):
                continue
            flashed.append(current)
            indices = self.get_neighbor_indices(current)
            for ri, ci in indices:
                if (self.check_bounds(ri, ci)):
                    self.matrix[ri, ci] += 1

            new_flashes = [item for item in self.get_flashers() if item not in flashed]
            frontier.extend(new_flashes)

        self.flashes += len(flashed)
        for r, c in flashed:
            self.matrix[r, c] = 0

    def iterate_matrix(self):
        # for r, c in np.ndindex(self.matrix.shape):
        self.matrix = self.increase_energy(self.matrix)
        self.handle_flashes()


class Solver1(SolverBase):
    def iterate(self, steps):
        for step in range(steps):
            self.iterate_matrix()


class Solver2(SolverBase):
    def all_ignited(self):
        return np.all(self.matrix == 0)

    def iterate(self):
        step = 0
        while (True):
            step += 1
            self.iterate_matrix()
            if (self.all_ignited()):
                return step
