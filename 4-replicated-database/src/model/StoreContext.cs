using Microsoft.EntityFrameworkCore;
using Store.Entities;
using Store.Model.DataSeed;

namespace Store.Model
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }


        public StoreContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(ProductSeed.GetSeedData());
        }
    }
}