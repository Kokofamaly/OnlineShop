using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users{get;set;} = null!;
    public DbSet<Order> Orders{get;set;} = null!;
    public DbSet<OrderItem> OrderItems{get;set;} = null!;
    public DbSet<Product> Products{get;set;} = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}