using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteTag> QuoteTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 1, Text = "Blablabla very smart quote :)" });
            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 2, Text = "Blablabla very another smart quote :)" });
            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 3, Text = "Kdo pozdě chodí, sám sobě škodí." });

            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 1, Name = "Kohout", Category = Category.Author });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 2, Name = "Pepa Autor", Category = Category.Author });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 3, Name = "České příslový", Category = Category.Genre });

            modelBuilder.Entity<QuoteTag>().HasData(new QuoteTag { Id = 1, QuoteId = 1, TagId = 1 });
            modelBuilder.Entity<QuoteTag>().HasData(new QuoteTag { Id = 2, QuoteId = 2, TagId = 2});
            modelBuilder.Entity<QuoteTag>().HasData(new QuoteTag { Id = 3, QuoteId = 3, TagId = 3});
        }
    }
}
