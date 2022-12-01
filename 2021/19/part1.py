from itertools import combinations
def get_distance(source, destination):
    return abs(abs(source) - abs(destination))

def get_distances(beacons):
    pairs = combinations(beacons, 2)
    distances = list()
    for pair in pairs:
        source, destination = pair
        distance = (
            get_distance(source[0], destination[0]),
            get_distance(source[1], destination[1]),
            get_distance(source[2], destination[2])
        )
        distances.append(distance)
    return distances


def parse_segment(segment):
    # cast str -> tuple of ints
    result = list()
    for line in segment:
        result.append(tuple(int(x) for x in line.split(",")))
    return result

def main():
    with open("19/input.txt", encoding="UTF-8") as file:
        segments = file.read().split("\n\n")

    segments = [parse_segment(segment.splitlines()[1:]) for segment in segments]
    first_segment = segments[0]
    segments = segments[1:]
    all_beacons = set().update(first_segment)

    d1 = get_distances(first_segment)
    d2 = get_distances(segments[0])


    # for segment in segments:
    print()


if __name__ == "__main__":
    main()
