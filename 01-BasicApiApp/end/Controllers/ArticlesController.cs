using System.Collections.Generic;
using Articles.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ConsoleApplication.Articles
{
    [Route("/api/[controller]")]
    public class ArticlesController : Controller
    {
        private static List<Article> _Articles = new List<Article>(new[] {
          new Article() { Id = 1, Title = "Intro to ASP.NET Core" },
          new Article() { Id = 2, Title = "Docker Fundamentals" },
          new Article() { Id = 3, Title = "Deploying to Azure with Docker" },
        });

        [HttpGet]
        public string Get() => "Hello, from the controller!!!";

        [HttpGet("{id:int}")]
        public IEnumerable<Article> Get(int id)
        {
            OkOrNotFound(await _context.Articles.SingleOrDefaultAsync(a => a.Id == id));
        }
    }
}
