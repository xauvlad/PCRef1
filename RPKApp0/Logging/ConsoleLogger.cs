using System;

namespace RefactoringExample.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.UtcNow:o}: {message}");
        }
    }
}
