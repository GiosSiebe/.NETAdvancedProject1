using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;
using Microsoft.EntityFrameworkCore;

namespace WineCode.Data
{
    public class WineContext : DbContext
    {
        public WineContext() { }

        public WineContext(DbContextOptions<WineContext> options) : base(options) { 
        }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>().ToTable("Wine");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Kind>().ToTable("Kind");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<Favorite>().ToTable("Favorite");
            modelBuilder.Entity<User>().ToTable("User");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WineAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
