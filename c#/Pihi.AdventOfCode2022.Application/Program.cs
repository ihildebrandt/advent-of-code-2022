using Pihi.AdventOfCode2022.Day08;

var day = 8;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();