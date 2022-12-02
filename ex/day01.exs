{:ok, contents} = File.read("input/01/input.txt")
contents
  |> String.split("\n")
  |> Enum.chunk_by(fn x -> x == "" end)
  |> Enum.filter(fn x -> Enum.at(x, 0) != "" end)
  |> Enum.map(fn x -> Enum.map(x, fn y -> String.to_integer(y) end) end)
  |> Enum.map(fn x -> Enum.sum(x) end)
  |> Enum.sort
  |> Enum.reverse
  |> Enum.slice(0, 3)
  |> Enum.sum
  |> IO.puts
