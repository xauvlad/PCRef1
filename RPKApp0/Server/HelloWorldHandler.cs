using System.IO;
using System.Net;
using System.Text;

namespace RefactoringExample.Server
{
    public class HelloWorldHandler : IRequestHandler
    {
        public void Handle(HttpListenerContext context)
        {
            string responseString = "Hello World";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            context.Response.ContentLength64 = buffer.Length;
            using (Stream output = context.Response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
