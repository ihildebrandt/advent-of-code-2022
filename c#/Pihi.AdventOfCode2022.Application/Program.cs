using Pihi.AdventOfCode2022.Day09;

var day = 9;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();