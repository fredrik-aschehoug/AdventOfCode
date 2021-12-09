import numpy as np
import numpy.ma as ma


def get_heightmap(file_content):
    columns = len(file_content.split("\n")[0])
    points = [int(point) for point in list(file_content.replace("\n", ""))]
    heightmap = ma.array(points).reshape(-1, columns)
    return heightmap


def get_bounds(matrix):
    row_bounds = range(matrix.shape[0])
    col_bounds = range(matrix.shape[1])
    return row_bounds, col_bounds


def mask_heighmap(heightmap):
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
