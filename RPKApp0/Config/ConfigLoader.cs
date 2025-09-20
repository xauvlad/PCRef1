using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace RefactoringExample.Config
{
    public static class ConfigLoader
    {
        public static (string Host, string Port) LoadConfig()
        {
            try
            {
                #if NETFRAMEWORK
                    string host = ConfigurationManager.AppSettings["Host"] ?? "localhost";
                    string port = ConfigurationManager.AppSettings["Port"] ?? "8080";
                    return (host, port);
                #else
                    IConfiguration config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false)
                        .Build();

                    string host = config["Server:Host"] ?? "localhost";
                    string port = config["Server:Port"] ?? "8000";
                    return (host, port);
                #endif
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to load config: {ex.Message}");
                return ("localhost", "8080");
            }
        }
    }
}
