import numpy as np


def get_matrix(file_content):
    columns = len(file_content.split("\n")[0])
    nodes = [int(level) for level in list(file_content.replace("\n", ""))]
    matrix = np.array(nodes).reshape(-1, columns)
    return matrix
