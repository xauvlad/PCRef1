using System.Net;

namespace RefactoringExample.Server
{
    public interface IRequestHandler
    {
        void Handle(HttpListenerContext context);
    }
}