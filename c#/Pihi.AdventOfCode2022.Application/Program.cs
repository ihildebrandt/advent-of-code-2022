using Pihi.AdventOfCode2022.Day02;

var day = 2;
var input = "input";

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
new Runner(inputStream).Run();