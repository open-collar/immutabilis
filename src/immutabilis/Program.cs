namespace immutabilis;

/// <summary>
/// The primary applciation class.
/// </summary>
public static class Program
{
    /// <summary>
    /// The main application entry point.
    /// </summary>
    /// <param name="args">The arguments passed to the application on the command line.</param>
    /// <returns>The result code from running the application.</returns>
    public static async Task<int> Main(string[] args)
    {
        var application = new Application(new ConsoleWriter());

        return (int)await application.Main(args);
    }
}