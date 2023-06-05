using CRM_Server_Side.Models.Database.Entitys;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Models.Database;

public class ShopContext : DbContext
{
    public DbSet<ProductType> ProductTypes { get; set; } = null!;
    public DbSet<VisitedProductsByCustomer> VisitedProductsByCustomers { get; set; } = null!;
    public DbSet<Supplies> Supplies { get; set; } = null!;
    public DbSet<Card> Cards { get; set; } = null!;
    public DbSet<CardItem> CardItems { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductInfo> ProductInfos { get; set; } = null!;
    public DbSet<Sales> Sales { get; set; } = null!;
    
    
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     
    //     optionsBuilder.UseLazyLoadingProxies().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //
    // }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Card>()
        //     .HasOne(u => u.Customer)
        //     .WithOne(p => p.Card)
        //     .HasForeignKey<Customer>(p => p.CardId);


        base.OnModelCreating(modelBuilder);
    }
}