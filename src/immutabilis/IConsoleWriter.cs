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
