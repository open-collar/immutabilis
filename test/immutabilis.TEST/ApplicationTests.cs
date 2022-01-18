using System.Threading.Tasks;

using Xunit;

namespace immutabilis.TEST
{
    public class ApplicationTests
    {
        [Fact]
        public async Task TextMainAsync()
        {
            var console = new ConsoleWriterMock();

            var application = new Application(console);

            var result = await application.Main(new string[0]);

            Assert.Equal(ResultCode.NoArgs, result);
            Assert.Equal(2, console.Output.Count);

        }
    }
}