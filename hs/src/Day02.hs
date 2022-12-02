module Day02 (run) where

opRock :: Char
opRock = 'A'

opPaper :: Char
opPaper = 'B'

opScissors :: Char
opScissors = 'C'

meRock :: Char
meRock = 'X'

mePaper :: Char
mePaper = 'Y'

meScissors :: Char
meScissors = 'Z'

strategyLose :: Char
strategyLose = 'X'

strategyDraw :: Char
strategyDraw = 'Y'

strategyWin :: Char
strategyWin = 'Z'

winScore :: Int
winScore = 6

drawScore :: Int
drawScore = 3

run :: IO ()
run = do
    contents <- readFile "../input/02/input.txt"
    print . scoreGames
          . lines $ contents

scoreGames :: [String] -> Int
scoreGames xs = sg xs 0
    where
        sg ((op:' ':strategy:[]):rest) score = do
            let me = evaluateStrategy op strategy
            let result = evaluateGame op me
            sg rest $ (score + result + (moveScore me))
        sg [] score = score

evaluateGame :: Char -> Char -> Int
evaluateGame op me
    | op == opRock && me == meRock = drawScore
    | op == opPaper && me == mePaper = drawScore
    | op == opScissors && me == meScissors = drawScore
    | op == opRock && me == mePaper = winScore
    | op == opPaper && me == meScissors = winScore
    | op == opScissors && me == meRock = winScore
    | otherwise = 0

moveScore :: Char -> Int
moveScore me
    | me == meRock = 1
    | me == mePaper = 2
    | me == meScissors = 3
    | otherwise = error "Invalid move"

evaluateStrategy :: Char -> Char -> Char
evaluateStrategy op strategy
    | strategy == strategyWin = evaluateWin op
    | strategy == strategyDraw = evaluateDraw op
    | strategy == strategyLose = evaluateLose op
    | otherwise = error "Invalid strategy"
        where
            evaluateWin strategyOp
                | strategyOp == opRock = mePaper
                | strategyOp == opPaper = meScissors
                | strategyOp == opScissors = meRock
                | otherwise = error "Invalid move"
            evaluateDraw strategyOp
                | strategyOp == opRock = meRock
                | strategyOp == opPaper = mePaper
                | strategyOp == opScissors = meScissors
                | otherwise = error "Invalid move"
            evaluateLose strategyOp
                | strategyOp == opRock = meScissors
                | strategyOp == opPaper = meRock
                | strategyOp == opScissors = mePaper
                | otherwise = error "Invalid move"
