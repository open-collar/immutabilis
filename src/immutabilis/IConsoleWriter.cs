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

namespace immutabilis
{
    /// <summary>
    /// A class that allows color messages to be written to the console in a threadsafe way.
    /// </summary>
    internal interface IConsoleWriter
    {
        /// <summary>
        /// Write the text given to the console, using the color specfied.
        /// </summary>
        /// <param name="color">The foreground color in which to write the text.</param>
        /// <param name="text">The text to write.</param>
        public void Write(ConsoleColor color, string text);

        /// <summary>
        /// Write the text given to the console followed by the current line terminator, using the color specfied.
        /// </summary>
        /// <param name="color">The foreground color in which to write the text.</param>
        /// <param name="text">The text to write.</param>
        public void WriteLine(ConsoleColor color, string text);
    }
}
