using System;
using System.Net;

namespace RefactoringExample.Middleware
{
    public interface IMiddleware
    {
        void Invoke(HttpListenerContext context, Action next);
    }
}
