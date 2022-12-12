using Pihi.AdventOfCode2022.Day11;

var day = 11;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();