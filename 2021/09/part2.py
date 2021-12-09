import numpy as np
from math import prod
from utils import get_heightmap, get_bounds, mask_heighmap


def search(heightmap, row, col):
    row_bounds, col_bounds = get_bounds(heightmap)
    basin = list()
    basin.append((row, col))
    frontier = list()
    frontier.append((row, col))

    while len(frontier) > 0:
        r, c = frontier.pop()
        neighbor_indices = [
            (r - 1, c), (r, c - 1), (r, c + 1), (r + 1, c)
        ]

        for r_i, c_i in neighbor_indices:
            if (r_i in row_bounds and c_i in col_bounds and heightmap.data[r_i, c_i] != 9 and (r_i, c_i) not in basin):
                basin.append((r_i, c_i))
                frontier.append((r_i, c_i))
    return basin


def main():
    with open("09/input.txt", encoding="UTF-8") as file:
        content = file.read()

    heightmap = get_heightmap(content)

    mask_heighmap(heightmap)

    lowest_points = np.argwhere(heightmap.mask)
    basins = list()
    for r, c in lowest_points:
        basin = search(heightmap, r, c)
        basins.append(basin)

    basin_sizes = [len(basin) for basin in basins]
    basin_sizes.sort()
    top = basin_sizes[-3:]
    result = prod(top)

    print(result)


if __name__ == "__main__":
    main()
