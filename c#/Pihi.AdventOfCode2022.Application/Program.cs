using Pihi.AdventOfCode2022.Day04;

var day = 4;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();