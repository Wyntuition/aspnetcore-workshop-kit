using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                //.Configure(app => app.Run(context => context.Response.WriteAsync("Hello World, from ASP.NET!")))

                .UseContentRoot(Directory.GetCurrentDirectory())
                //UseIISIntegration()
                .UseStartup<Startup>()

                .Build();

            host.Run();
        }
    }
}
