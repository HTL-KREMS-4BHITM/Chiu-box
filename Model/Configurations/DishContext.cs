using Microsoft.EntityFrameworkCore;
using Model.Entites;

namespace Model.Configurations;

public class DishContext : DbContext
{
    public DishContext(DbContextOptions<DishContext> options) : base(options)
    {
        
    }
    
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShopSchedule> ShopSchedule { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllergenDishesJT>()
            .HasKey(j => new { j.DishId, j.AllergenId });
        modelBuilder.Entity<AllergenDishesJT>()
            .HasOne(j => j.Dish)
            .WithMany()
            .HasForeignKey(j => j.DishId);
        modelBuilder.Entity<AllergenDishesJT>()
            .HasOne(j => j.Allergen)
            .WithMany()
            .HasForeignKey(j => j.AllergenId);
        
        modelBuilder.Entity<CategoriesDishesJT>()
            .HasKey(j => new { j.DishId, j.CategoryId });
        modelBuilder.Entity<CategoriesDishesJT>()
            .HasOne(j => j.Dish)
            .WithMany()
            .HasForeignKey(j => j.DishId);
        modelBuilder.Entity<CategoriesDishesJT>()
            .HasOne(j => j.Category)
            .WithMany()
            .HasForeignKey(j => j.CategoryId);
        
    }
}