using System.Collections.Generic;
using Articles.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ConsoleApplication.Infrastructure;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication.Articles
{
    [Route("/api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly ArticlesContext _context;
        private readonly ILogger<ArticlesController> _logger; 

        public ArticlesController(ArticlesContext context, ILogger<ArticlesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Article>> Get() => await _context.Set<Article>().ToListAsync();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound(); // This makes it return 404; otherwise it will return a 204 (no content) 
            }

            return new ObjectResult(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Article article)
        {
            _logger.LogDebug("Starting save");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articles.Add(new Article { Title = article.Title });
            await _context.SaveChangesAsync();

            _logger.LogDebug("Finished save");

            return CreatedAtAction(nameof(Get), new { id = article.Title }, article);
        }
    }
}
