using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Common
{
    public abstract class RunnerBase
    {
        private readonly Stream _inputStream;

        public RunnerBase(Stream inputStream)
        {
            _inputStream = inputStream;
        }

        public IEnumerable<string> ReadLines()
        {
            _inputStream.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(_inputStream);
            
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public abstract void Run();
    }
}
