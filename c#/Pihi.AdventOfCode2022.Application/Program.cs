using Pihi.AdventOfCode2022.Day01;

var day = 1;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Day1Runner(inputStream).Run();