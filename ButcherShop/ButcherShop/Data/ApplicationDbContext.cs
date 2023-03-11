using ButcherShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ButcherShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {

        }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<MeatType> MeatTypes { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Butcher> Butchers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<DeliveryCompany> DeliveryCompanies { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Minced Pork",
                    Price = 10,
                    Quantity = 100,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Chicken Wing",
                    Price = 5,
                    Quantity = 150,
                }, new Product()
                {
                    Id = 3,
                    Name = "Minced Beef",
                    Price = 7.5,
                    Quantity = 200,
                },
                new Product()
                {
                    Id = 4,
                    Name = "Chicken breast",
                    Price = 8,
                    Quantity = 100,
                });

                        
        }


    }
}
