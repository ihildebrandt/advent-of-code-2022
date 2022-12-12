using Pihi.AdventOfCode2022.Common;
using System.Reflection;

var input = args[1];
var day = int.Parse(args[0]);

var assembly = Assembly.LoadFrom($"./Pihi.AdventOfCode2022.Day{day:00}.dll");
var type = assembly.GetExportedTypes().Single(t => t.IsAssignableTo(typeof(RunnerBase)));
var constructor = type.GetConstructor(new Type[] { typeof(Stream) });

using var inputStream = File.OpenRead($"input/{day:00}/{input}.txt");
var runner = (RunnerBase)(constructor.Invoke(new[] { inputStream }));
runner.Run();