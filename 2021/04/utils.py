import numpy.ma as ma


def get_boards(raw_boards):
    columns = len(raw_boards[0].split("\n")[0].split())
    boards = list()

    for raw_board in raw_boards:
        numbers = [int(n) for n in raw_board.replace("\n", " ").split()]
        board = ma.array(numbers, dtype="i").reshape(-1, columns)
        boards.append(board)

    return boards


def mark_boards(boards, number):
    updated_boards = list()
    for board in boards:
        updatedBoard = ma.masked_values(board, number)
        updated_boards.append(updatedBoard)
    return updated_boards


def get_score(winner, number):
    sum = winner.sum()
    return sum * number
