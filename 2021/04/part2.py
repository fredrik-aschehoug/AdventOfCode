from utils import get_boards, mark_boards, get_score
import numpy as np


def check_winners(boards):
    winners = list()

    for board in boards:
        if (not board.mask.any()):
            continue
        row_sum = board.mask.all(axis=0)
        column_sum = board.mask.all(axis=1)

        if (column_sum.any() or row_sum.any()):
            winners.append(board)

    return winners


def main():
    with open("04/input.txt", encoding="UTF-8") as file:
        content = file.read()

    numbers = [int(number) for number in content.split("\n\n")[0].split(",")]
    boards = get_boards(content.split("\n\n")[1:])
    winners = list()
    winning_number = 0

    for number in numbers:
        boards = mark_boards(boards, number)
        current_winners = check_winners(boards)

        if (len(current_winners) > 0):
            winning_number = number
            winners.extend(current_winners)

            # Remove winners from boards
            for winner in current_winners:
                boards = list(filter(lambda x: not np.array_equal(x, winner), boards))

    last_winner = winners[-1]
    score = get_score(last_winner, winning_number)
    print(score)


if __name__ == "__main__":
    main()
