using Xunit;
using RefactoringExample.Logging;
using System.IO;

namespace Tests
{
    public class LoggerTests
    {
        [Fact]
        public void ConsoleLogger_ShouldWriteMessage()
        {
            var logger = new ConsoleLogger();

            var ex = Record.Exception(() => logger.Log("test message"));
            Assert.Null(ex);
        }

        [Fact]
        public void FileLogger_ShouldWriteToFile()
        {
            var path = "test_log.txt";
            if (File.Exists(path)) File.Delete(path);

            var logger = new FileLogger(path);

            logger.Log("Hello Test");

            var content = File.ReadAllText(path);
            Assert.Contains("Hello Test", content);
        }
    }
}
