from utils import get_boards, mark_boards, get_score


def check_winner(boards):
    for board in boards:
        if (not board.mask.any()):
            return None
        row_sum = board.mask.all(axis=0)
        column_sum = board.mask.all(axis=1)

        if (column_sum.any() or row_sum.any()):
            return board


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


if __name__ == "__main__":
    main()
