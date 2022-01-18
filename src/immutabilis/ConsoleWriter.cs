namespace immutabilis
{
    /// <summary>
    /// A class that allows color messages to be written to the console in a threadsafe way.
    /// </summary>
    internal class ConsoleWriter:IConsoleWriter
    {
        /// <summary>
        /// The a lock token used to control concurrent access to the <see cref="System.Console"/> members.
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        /// Write the text given to the console, using the color specfied.
        /// </summary>
        /// <param name="color">The foreground color in which to write the text.</param>
        /// <param name="text">The text to write.</param>
        public void Write(ConsoleColor color, string text)
        {
            lock (_lock)
            {
                var originalColor = System.Console.ForegroundColor;
                System.Console.ForegroundColor = color;
                System.Console.Write(text);
                System.Console.ForegroundColor = originalColor;
            }
        }

        /// <summary>
        /// Write the text given to the console followed by the current line terminator, using the color specfied.
        /// </summary>
        /// <param name="color">The foreground color in which to write the text.</param>
        /// <param name="text">The text to write.</param>
        public void WriteLine(ConsoleColor color, string text)
        {
            lock (_lock)
            {
                var originalColor = System.Console.ForegroundColor;
                System.Console.ForegroundColor = color;
                System.Console.WriteLine(text);
                System.Console.ForegroundColor = originalColor;
            }
        }
    }
}
