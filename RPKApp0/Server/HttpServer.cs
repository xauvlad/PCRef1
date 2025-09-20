using System;
using System.Net;
using System.Threading;
using RefactoringExample.Config;
using RefactoringExample.Logging;
using RefactoringExample.Middleware;

namespace RefactoringExample.Server
{
    public class HttpServer
    {
        private readonly ServerConfig config;
        private readonly ILogger logger;
        private readonly IRequestHandler handler;
        private readonly MiddlewarePipeline pipeline = new();

        public HttpServer(ServerConfig config, ILogger logger, IRequestHandler handler)
        {
            this.config = config;
            this.logger = logger;
            this.handler = handler;
        }

        public void Use(IMiddleware middleware) => pipeline.Use(middleware);

        public void Start()
        {
            var listener = new HttpListener();
            string prefix = $"http://{config.Host}:{config.Port}/";
            listener.Prefixes.Add(prefix);

            try
            {
                listener.Start();
            }
            catch (Exception ex)
            {
                logger.Log($"Failed to start server: {ex.Message}");
                return;
            }

            logger.Log($"Server started at {config.Host}:{config.Port}");

            var timer = new Timer(_ => logger.Log("Server heartbeat"), null, 60000, 60000);

            while (true)
            {
                var context = listener.GetContext();
                logger.Log($"Request received: {context.Request.Url}");
                pipeline.Execute(context, () => handler.Handle(context));
            }
        }
    }
}
