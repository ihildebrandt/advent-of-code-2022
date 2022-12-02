rock = "R"
paper = "P"
scissors = "S"

win = "W"
lose = "L"
draw = "D"

move = {
    "A": rock,
    "B": paper,
    "C": scissors,
    "X": rock,
    "Y": paper,
    "Z": scissors
}

op_moves = {
    rock: "A",
    paper: "B",
    scissors: "C"
}

my_moves = {
    rock: "X",
    paper: "Y",
    scissors: "Z"
}

my_winning_moves = {
    rock: my_moves[paper],
    paper: my_moves[scissors],
    scissors: my_moves[rock]
}

my_losing_moves = {
    rock: my_moves[scissors],
    paper: my_moves[rock],
    scissors: my_moves[paper]
}

strategy = {
    "X": lose, 
    "Y": draw, 
    "Z": win
}

move_score = {
    rock: 1,
    paper: 2,
    scissors: 3
}

def evaluate_game(op, me):
    if move[op] == rock:
        if move[me] == rock:
            return draw
        elif move[me] == paper:
            return win
        else:
            return lose
    elif move[op] == paper:
        if move[me] == rock:
            return lose
        elif move[me] == paper:
            return draw
        else:
            return win
    else:
        if move[me] == rock:
            return win
        elif move[me] == paper:
            return lose
        else:
            return draw

def evaluate_strategy(o, s):
    the_strategy = strategy[s]
    if the_strategy == win:
        return my_winning_moves[move[o]]
    elif the_strategy == lose:
        return my_losing_moves[move[o]]
    else:
        return my_moves[move[o]]

def evaluate_score(op, me):
    score = 0
    result = evaluate_game(op, me)
    if result == win:
        score += 6
    elif result == draw:
        score += 3
    score += move_score[move[me]]
    return score

def main():
    f = open("../input/02/input.txt", "r")

    score = 0
    for line in f.readlines():
        moves = line.strip().split(" ")
        op = moves[0]
        # me = moves[1]
        me = evaluate_strategy(op, moves[1])
        score += evaluate_score(op, me)
    print(score)


if __name__ == "__main__":
    main()
