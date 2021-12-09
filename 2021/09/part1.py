import numpy as np
import numpy.ma as ma
from utils import get_heightmap, get_bounds


def main():
    with open("09/input.txt", encoding="UTF-8") as file:
        content = file.read()

    heightmap = get_heightmap(content)
    row_bounds, col_bounds = get_bounds(heightmap)

    for row_index, col_index in np.ndindex(heightmap.shape):
        neighbor_indices = [
            (row_index - 1, col_index), (row_index, col_index - 1), (row_index, col_index + 1), (row_index + 1, col_index)
        ]
        neighbours = list()
        for r_i, c_i in neighbor_indices:
            if (r_i in row_bounds and c_i in col_bounds):
                neighbours.append(heightmap.data[r_i, c_i])

        if (heightmap[row_index, col_index] < min(neighbours)):
            heightmap[row_index, col_index] = ma.masked

    lowest_points = heightmap[heightmap.mask].data
    risk_level = len(lowest_points)

    print(sum(lowest_points) + risk_level)


if __name__ == "__main__":
    main()
