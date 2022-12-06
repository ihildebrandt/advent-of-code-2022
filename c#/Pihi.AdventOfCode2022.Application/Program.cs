using Pihi.AdventOfCode2022.Day06;

var day = 6;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();