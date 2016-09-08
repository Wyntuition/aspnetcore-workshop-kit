using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .Configure(app => app.Run(context => context.Response.WriteAsync("Hello World, from ASP.NET!")))
                .Build();

            host.Run();
        }
    }
}
