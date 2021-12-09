from utils import get_heightmap, mask_heighmap


def main():
    with open("09/input.txt", encoding="UTF-8") as file:
        content = file.read()

    heightmap = get_heightmap(content)

    mask_heighmap(heightmap)

    lowest_points = heightmap[heightmap.mask].data
    risk_level = len(lowest_points)

    print(sum(lowest_points) + risk_level)


if __name__ == "__main__":
    main()
