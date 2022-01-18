using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace immutabilis
{
    /// <summary>
    /// The class implementing the core functionality of the application.
    /// </summary>
    internal class Application
    {

        /// The console writer that will be used to write output.
        private readonly IConsoleWriter _consoleWriter;

        /// <summary>
        /// Creates a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="consoleWriter">The console writer that will be used to write output.</param>
        internal Application(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The arguments passed to the application on the command line.</param>
        /// <returns>The result of running the application.</returns>
        public async Task<ResultCode> Main(string[] args)
        {
            var assembly = typeof(Application).Assembly;

            _consoleWriter.Write(ConsoleColor.DarkGray, System.IO.Path.GetFileNameWithoutExtension(assembly.Location));
            _consoleWriter.Write(ConsoleColor.DarkGray, " ");
            _consoleWriter.WriteLine(ConsoleColor.White, assembly.GetName().Version!.ToString(4));

            if (args.Length <= 0)
            {
                _consoleWriter.WriteLine(ConsoleColor.Red, "No arguments supplied.");
                return ResultCode.NoArgs;
            }

            // Do stuff here

            return ResultCode.Success;
        }
    }
}
