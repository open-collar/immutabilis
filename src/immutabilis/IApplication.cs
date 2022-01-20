
namespace immutabilis
{
    /// <summary>
    /// The public interface of the service that provides the main entry point for the application.
    /// </summary>
    internal interface IApplication
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The arguments passed to the application on the command line.</param>
        /// <returns>The result of running the application.</returns>
        Task<ResultCode> Main(string[] args);
    }
}