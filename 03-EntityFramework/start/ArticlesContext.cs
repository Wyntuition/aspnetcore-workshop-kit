using Microsoft.EntityFrameworkCore;
using Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Articles.Infrastructure
{
    public class ArticlesContext : DbContext
    {
        public DbSet<Article> Article { get; set; }
        public DbSet<Error> Errors { get; set; }

        public ArticlesContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            modelBuilder.Entity<Article>().Property(p => p.Title).IsRequired();
        }
    }
  }
