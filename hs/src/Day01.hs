module Day01 (run) where

import Data.List 

run :: IO ()
run = do 
    contents <- readFile "input/01/input.txt"
    print . foldl (+) 0
          . take 3
          . reverse
          . sort
          . parseLines
          . lines $ contents

parseLines :: [String] -> [Integer]
parseLines xs = pl xs [0]
    where 
        pl ("":ys) acc = pl ys $ (acc ++ [0])
        pl (y:ys) acc = pl ys $ ((init acc) ++ [(last acc) + (readInt y)])
        pl [] acc = acc

readInt :: String -> Integer
readInt = read
