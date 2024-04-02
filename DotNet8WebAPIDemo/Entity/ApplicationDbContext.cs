using DotNet8WebAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebAPIDemo.Entity
{
    public class ApplicationDbContext :DbContext
    {
        //Step-1 Add require nuget packages
        //Step-2 Add ApplicationDbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        // Step-3 Registered DB Model
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        //Step-4 Data Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<Product>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName ="Computer",
                    tags="Computer Accessories",
                    isActive = true,
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    Username = "System",
                    Password = "System",
                }
            );
        }
    }
}
