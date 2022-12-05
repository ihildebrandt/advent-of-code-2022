using Pihi.AdventOfCode2022.Day05;

var day = 5;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();