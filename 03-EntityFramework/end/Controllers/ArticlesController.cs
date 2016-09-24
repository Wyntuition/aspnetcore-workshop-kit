using System.Collections.Generic;
using Articles.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ConsoleApplication.Infrastructure;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication.Articles
{
    [Route("/api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly ArticlesContext _context;
        public ArticlesController(ArticlesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Article>> Get() => await _context.Set<Article>().ToListAsync();

        [HttpGet("{id:int}")]
        public async Task<Article> Get(int id)
        {
            return await _context.Articles.SingleOrDefaultAsync(a => a.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articles.Add(new Article { Title = article.Title });
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = article.Title }, article);
        }
    }
}
