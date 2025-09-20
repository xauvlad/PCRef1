using System;
using System.Collections.Generic;
using System.Net;

namespace RefactoringExample.Middleware
{
    public class MiddlewarePipeline
    {
        private readonly List<IMiddleware> middlewares = new();

        public void Use(IMiddleware middleware) => middlewares.Add(middleware);

        public void Execute(HttpListenerContext context, Action finalHandler)
        {
            int index = -1;
            Action next = null;

            next = () =>
            {
                index++;
                if (index < middlewares.Count)
                    middlewares[index].Invoke(context, next);
                else
                    finalHandler();
            };

            next();
        }
    }
}
