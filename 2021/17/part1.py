

def simulate_launch(x, y, target):
    x_pos = 0
    x_increment = x
    y_pos = 0
    y_increment = y
    y_target = range(target["y"]["min"], target["y"]["max"])
    x_target = range(target["x"]["min"], target["x"]["max"])

    velocities = list()
    for i in range(1000):
        if x_increment > 0:
            x_pos += x_increment
            x_increment -= 1
        y_pos += y_increment
        y_increment -= 1
        if x_pos in x_target and y_pos in y_target:
            velocities.append((x, y))
        if x_pos > target["x"]["max"] and y_pos > target["y"]["min"]:
            break
    return velocities


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

    for x in range(15, 19):
        for y in range(target["y"]["min"], 200):
            current_velocities = simulate_launch(x, y, target)
            velocities.extend(current_velocities)

    velocities_with_max_y = [get_max_y(velocity) for velocity in velocities]
    max_y = max(velocities_with_max_y)
    print(max_y)


if __name__ == "__main__":
    main()
