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


def check_winner(boards):
    for board in boards:
        if (not board.mask.any()):
            return None
        row_sum = board.mask.all(axis=0)
        column_sum = board.mask.all(axis=1)

        if (column_sum.any() or row_sum.any()):
            return board


def get_score(winner, number):
    sum = winner.sum()
    return sum * number


def main():
    with open("04/input.txt", encoding="UTF-8") as file:
        content = file.read()

    numbers = [int(number) for number in content.split("\n\n")[0].split(",")]
    boards = get_boards(content.split("\n\n")[1:])

    for number in numbers:
        boards = mark_boards(boards, number)
        winner = check_winner(boards)
        if (winner is not None):
            score = get_score(winner, number)
            print(score)
            break

    print()


if __name__ == "__main__":
    main()
