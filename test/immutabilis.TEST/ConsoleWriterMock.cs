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
