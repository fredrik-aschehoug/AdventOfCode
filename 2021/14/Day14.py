steps = 40


def apply_rules(char_count, rules, pair_count):
    current_count = pair_count.copy()

    for key, val in rules.items():
        rule_count = pair_count.get(key, 0)
        if (rule_count > 0):
            current_count[val[0]] = current_count.get(val[0], 0) + rule_count
            current_count[val[1]] = current_count.get(val[1], 0) + rule_count
            current_count[key] -= rule_count

            char_count[val[0][1]] = char_count.get(val[0][1], 0) + rule_count

    for key, val in current_count.items():
        pair_count[key] = val


def calculate_result(char_count):
    bincount = list(char_count.values())
    bincount.sort()
    most = bincount[-1]
    least = bincount[0]

    return most - least


def main():
    with open("14/input.txt", encoding="UTF-8") as file:
        content = file.read()

    template, rest = content.split("\n\n")
    rest = [rule.split(" -> ") for rule in rest.splitlines()]
    rules = {rule[0]: [rule[0][0] + rule[1], rule[1] + rule[0][1]] for rule in rest}

    pair_count = dict()
    for i in range(len(template) - 1):
        pair_count[template[i:i + 2]] = pair_count.get(template[i:i + 2], 0) + 1

    char_count = dict()
    for c in template:
        char_count[c] = char_count.get(c, 0) + 1

    for step in range(1, steps + 1):
        apply_rules(char_count, rules, pair_count)
        if (step == 10):
            result = calculate_result(char_count)
            print("Part 1: ", result)

    result = calculate_result(char_count)
    print("Part 2: ", result)


if __name__ == "__main__":
    main()
