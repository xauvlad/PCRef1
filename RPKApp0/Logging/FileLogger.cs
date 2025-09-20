using System;
using System.IO;

namespace RefactoringExample.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string filePath;

        public FileLogger(string filePath = "app.log")
        {
            this.filePath = filePath;
        }

        public void Log(string message)
        {
            try
            {
                File.AppendAllText(filePath, $"[LOG] {DateTime.UtcNow:o}: {message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
