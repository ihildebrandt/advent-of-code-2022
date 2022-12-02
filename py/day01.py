from functools import reduce
from operator import add

def main():
    f = open("../input/01/input.txt", "r")
    
    calories = [0]
    calIdx = 0

    for line in f.readlines():
        if line.strip() == "":
            calories.append(0)
            calIdx += 1
        else:
            calories[calIdx] += int(line)

    calories.sort(reverse=True)
    print(reduce(add, calories[0:3]))

if __name__ == "__main__":
    main()
