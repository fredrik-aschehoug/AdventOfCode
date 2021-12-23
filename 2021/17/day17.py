

def simulate_launch(x, y, x_target, y_target, target):
    x_pos = 0
    x_increment = x
    y_pos = 0
    y_increment = y

    for i in range(1000):
        if x_increment > 0:
            x_pos += x_increment
            x_increment -= 1
        y_pos += y_increment
        y_increment -= 1
        if x_pos in x_target and y_pos in y_target:
            return (x, y)
        if x_pos > target["x"]["max"] and y_pos > target["y"]["min"]:
            break
    return None


def get_max_y(velocity):
    x, y = velocity
    max_y = y
    y_pos = 0
    y_increment = y
    for i in range(1000):
        y_pos += y_increment
        y_increment -= 1
        if y_pos > max_y:
            max_y = y_pos
    return max_y


def main():
    target = {
        "x": {
            "min": 124,
            "max": 174
        },
        "y": {
            "min": -123,
            "max": -86
        }
    }

    velocities = list()

    y_target = range(target["y"]["min"], target["y"]["max"] + 1)
    x_target = range(target["x"]["min"], target["x"]["max"] + 1)

    for x in range(500):
        for y in range(target["y"]["min"], 200):
            current_velocity = simulate_launch(x, y, x_target, y_target, target)
            if current_velocity:
                velocities.append(current_velocity)

    velocities_with_max_y = [get_max_y(velocity) for velocity in velocities]
    max_y = max(velocities_with_max_y)
    print("part 1: ", max_y)
    print("part 2: ", len(velocities))


if __name__ == "__main__":
    main()
