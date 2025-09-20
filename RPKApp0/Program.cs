using System;
using System.Threading;
using RefactoringExample.Config;
using RefactoringExample.Logging;
using RefactoringExample.Server;

namespace RefactoringExample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var config = ConfigLoader.LoadConfig();
            var logger = new CompositeLogger(new ConsoleLogger(), new FileLogger());
            var handler = new HelloWorldHandler();

            var server = new HttpServer(new ServerConfig { Host = config.Host, Port = config.Port }, logger, handler);

            var serverThread = new Thread(server.Start) { IsBackground = true };
            serverThread.Start();

            Console.WriteLine("Server started. Press Enter to stop.");
            Console.ReadLine();
        }
    }
}
