using Microsoft.EntityFrameworkCore;
using SkateSpotter_MVC.Models;

namespace SkateSpotter_MVC.Data
{
    public class ApplicationDBContext : DbContext
    {
        // db sets
        public DbSet<Spot> Spots { get; set; }
        public DbSet<Skater> Skaters { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }

        // constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        // override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
