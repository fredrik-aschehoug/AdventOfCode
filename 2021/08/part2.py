import numpy as np

# digit map
#   1
#  ----
# 4| 3 |2
#  ----
# 7|   |5
#  ----
#    6


def stupidly_get_digits_map(patterns):
    # Be careful reading this, you might get a headache

    digit_position_map = dict()

    length_checker = np.vectorize(len)
    lenght_vector = length_checker(patterns)

    one = patterns[np.argmax(lenght_vector == 2)]
    four = patterns[np.argmax(lenght_vector == 4)]
    seven = patterns[np.argmax(lenght_vector == 3)]
    eight = patterns[np.argmax(lenght_vector == 7)]
    possible_six = [pattern for pattern in patterns if len(pattern) == 6]
    six = [pattern for pattern in possible_six if len(set(one).intersection(set(pattern))) != len(one)].pop()

    digit_position_map[1] = set(seven) - set(one)
    digit_position_map[5] = list(set(one).intersection(set(six))).pop()
    digit_position_map[2] = list(set(one) - set(digit_position_map[5])).pop()

    three = [pattern for pattern in patterns if len(pattern) == 5 and seven[0] in pattern and seven[1] in pattern and seven[2] in pattern].pop()

    rest = [pattern for pattern in patterns if pattern not in [one, three, four, six, seven, eight]]

    two = [pattern for pattern in rest if len(pattern) == 5 and digit_position_map[2] in pattern].pop()
    five = [pattern for pattern in rest if len(pattern) == 5 and digit_position_map[5] in pattern].pop()
    possible_nine = [pattern for pattern in rest if len(pattern) == 6]
    nine = [option for option in possible_nine if len(set(five) - set(option)) == 0].pop()
    zero = [pattern for pattern in rest if pattern != two and pattern != five and pattern != nine].pop()

    digits_map = {
        zero: "0",
        one: "1",
        two: "2",
        three: "3",
        four: "4",
        five: "5",
        six: "6",
        seven: "7",
        eight: "8",
        nine: "9"
    }
    return digits_map


def get_key(pattern, keys):
    pattern_set = set(pattern)
    for key in keys:
        if (set(key) == pattern_set):
            return key


def get_output(patterns, digit_map):
    digit = ""
    keys = digit_map.keys()
    for pattern in patterns:
        key = get_key(pattern, keys)
        digit += digit_map[key]
    return int(digit)


def main():
    with open("08/input.txt", encoding="UTF-8") as file:
        content = file.read()
    lines = [line.split(" | ") for line in content.splitlines()]
    entries = [{"patterns": line[0].split(), "digits": line[1].split()}
               for line in lines]

    output_sum = 0
    for entry in entries:
        digit_map = stupidly_get_digits_map(entry["patterns"])
        output = get_output(entry["digits"], digit_map)
        output_sum += output

    print(output_sum)


if __name__ == "__main__":
    main()
