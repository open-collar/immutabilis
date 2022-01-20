/*
 * This file is part of immutabilis.
 *
 * Copyright © 2022 Xavier Evans (xavierevans341@gmail.com) and Jonathan Evans (jevans@open-collar.org.uk). All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */

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
    internal class Application : IApplication
    {

        /// The console writer that will be used to write output.
        private readonly IConsoleWriter _consoleWriter;

        /// <summary>
        /// Creates a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="consoleWriter">The console writer that will be used to write output.</param>
        public Application(IConsoleWriter consoleWriter)
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
