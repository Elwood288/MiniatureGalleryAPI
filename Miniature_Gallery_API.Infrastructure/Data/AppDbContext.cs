using System;
using Miniature_Gallery_API.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.IdentityModel.Xml.XmlSignatureConstants;
using System.Collections.Generic;

namespace Miniature_Gallery_API.Infrastructure.Data
{
    // TODO: inherit from IdentityDbContext
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Miniature> Miniatures { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        // NOTE that we don't have to define a Users DbSet. It is given to us by IdentityDbContext.

        //This method runs once when the DbContext is first used.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=../Miniature_Gallery_API.Infrastructure/MiniatureGallery.db");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("DataSource=../Miniature_Gallery_API.Infrastructure/MiniatureGallery.db");
        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


           

            //Game m_Game = new Game { Id = 1, Name = "Heroscape", Attributes = { "Army", "Species" } };

            //TODO: configure some seed data in the books table
            //Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //dictionary.Add("Army", "Jandar");
            //dictionary.Add("Species", "Human");


            builder.Entity<Miniature>().HasData(
                new Miniature { Id = 1, Name = "Testy McGee", Game = "Heroscape" }
            );

            builder.Entity<Keyword>().HasData(
              new { Id = 1, Name = "human", MiniatureId = 1 }
           );

           

        }
    }
}
