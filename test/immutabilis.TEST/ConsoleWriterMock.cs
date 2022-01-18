using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace immutabilis.TEST
{
    internal class ConsoleWriterMock : immutabilis.IConsoleWriter
    {
        public List<string> Output { get; } = new List<string>();

        private readonly object _lock = new object();

        private string? _unwritten;

        public void Write(ConsoleColor color, string text)
        {
            lock (_lock)
            {
                _unwritten = (_unwritten ?? string.Empty) +text;
            }
        }

        public void WriteLine(ConsoleColor color, string text)
        {
            lock (_lock)
            {
                _unwritten = (_unwritten ?? string.Empty) + text;
                Output.Add(_unwritten);
                _unwritten = null;
            }

        }
    }
}
