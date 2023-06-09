using Microsoft.EntityFrameworkCore;
using FoodMenuApi.Models;

namespace FoodMenuApi.Data
{
    public class MenuAppDbContext : DbContext
    {
        public MenuAppDbContext(DbContextOptions<MenuAppDbContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoodCategory>()
                .HasKey(c => c.Name);
        }
    }
}
