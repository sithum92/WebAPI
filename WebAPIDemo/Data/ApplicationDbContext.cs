using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models;

namespace WebAPIDemo.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Shirt> Shirts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //data seeding
            //modelBuilder.Entity<Shirt>().HasData(new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 10.00m, Size = 10 },
            //new Shirt { ShirtId = 2, Brand = "My Brand", Color = "Black", Gender = "Men", Price = 20.00m, Size = 12 },
            //new Shirt { ShirtId = 3, Brand = "Your Brand", Color = "Pink", Gender = "Women", Price = 30.00m, Size = 8 },
            //new Shirt { ShirtId = 3, Brand = "Your Brand", Color = "Yellow", Gender = "Women", Price = 30.00m, Size = 9 });
        }
    }
}
