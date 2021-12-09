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
