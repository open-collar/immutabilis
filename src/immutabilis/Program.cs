using Microsoft.Extensions.DependencyInjection;

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
        // We use services here to implement dependency injection.  This makes unit testing
        // simpler, and  later, when we add features such as extensibility, it will help.
        var services = new ServiceCollection();
        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        services.AddSingleton<IApplication, Application>();
        var provider = services.BuildServiceProvider();

        var application = provider.GetRequiredService<IApplication>();

        return (int)await application.Main(args);
    }
}