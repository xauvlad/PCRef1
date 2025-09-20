using System.Collections.Generic;

namespace RefactoringExample.Logging
{
    public class CompositeLogger : ILogger
    {
        private readonly List<ILogger> loggers = new();

        public CompositeLogger(params ILogger[] loggers)
        {
            this.loggers.AddRange(loggers);
        }

        public void Log(string message)
        {
            foreach (var logger in loggers)
                logger.Log(message);
        }
    }
}
