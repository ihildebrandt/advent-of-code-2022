using Pihi.AdventOfCode2022.Day03;

var day = 3;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();