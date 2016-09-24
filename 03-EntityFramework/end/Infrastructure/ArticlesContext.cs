using Articles.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication.Infrastructure
{
  public class ArticlesContext : DbContext
  {
      public DbSet<Article> Articles { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          optionsBuilder.UseSqlite("Filename=./articles.db");
      }
  }
}
