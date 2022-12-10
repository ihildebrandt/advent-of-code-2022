using Pihi.AdventOfCode2022.Day10;

var day = 10;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();