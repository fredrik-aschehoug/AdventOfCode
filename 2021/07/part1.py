def get_cost(all_positions, current_position):
    cost = 0
    for position in all_positions:
        cost += abs(position - current_position)
    return cost


def main():
    with open("07/input.txt", encoding="UTF-8") as file:
        content = file.read()
    positions = [int(position) for position in content.split(",")]
    top_position = max(positions)
    bottom_position = min(positions)
    costs = list()

    for position in range(bottom_position, top_position):
        cost = get_cost(positions, position)
        costs.append(cost)
    result = min(costs)
    print(result)


if __name__ == "__main__":
    main()
