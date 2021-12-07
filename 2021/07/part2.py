import sys


def get_triangular_number(n):
    return int(n * (n + 1) / 2)


def get_cost(all_positions, current_position):
    cost = 0
    for position in all_positions:
        steps = abs(position - current_position)
        cost += get_triangular_number(steps)
    return cost


def main():
    with open("07/input.txt", encoding="UTF-8") as file:
        content = file.read()
    positions = [int(position) for position in content.split(",")]
    top_position = max(positions)
    bottom_position = min(positions)
    min_cost = sys.maxsize

    for position in range(bottom_position, top_position):
        cost = get_cost(positions, position)
        if (cost < min_cost):
            min_cost = cost

    print(min_cost)


if __name__ == "__main__":
    main()
