using Pihi.AdventOfCode2022.Day07;

var day = 7;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();