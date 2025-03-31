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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}