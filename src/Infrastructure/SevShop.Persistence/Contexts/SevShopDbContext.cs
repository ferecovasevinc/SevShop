using Microsoft.EntityFrameworkCore;
using SevShop.Domain.Entities;
using SevShop.Persistence.Configurations;
using System.Net;

namespace SevShop.Persistence.Contexts;

public class SevShopDbContext : DbContext
{
    public SevShopDbContext(DbContextOptions<SevShopDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<AIChat> AIChats { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSizeColor> ProductSizeColors { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Size> Sizes { get; set; }
}
