import numpy as np

steps = 10


def apply_rules(template, rules):
    i = 0
    while i < len(template):
        pair = template[i:i + 2]
        char_to_insert = rules.get(pair, None)
        if (char_to_insert):
            template = template[:i + 1] + char_to_insert + template[i + 1:]
            i += 1
        i += 1

    return template


def main():
    with open("14/input.txt", encoding="UTF-8") as file:
        content = file.read()

    template, rest = content.split("\n\n")
    rest = [rule.split(" -> ") for rule in rest.splitlines()]
    rules = {rule[0]: rule[1] for rule in rest}

    for step in range(steps):
        template = apply_rules(template, rules)
        print("Current step: ", step, end="\r")

    bincount = np.unique(list(template), return_counts=True)[1]
    bincount.sort()
    most = bincount[-1]
    least = bincount[0]

    result = most - least
    print(result)


if __name__ == "__main__":
    main()
