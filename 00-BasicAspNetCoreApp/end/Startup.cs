using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        // Middleware is configured here.
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context => context.Response.WriteAsync("Hello World, from ASP.NET!"));
        }
    }
}
