using Flunt.Notifications;
using Iwant.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Iwant.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Category { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<Notification>();
        
        builder.Entity<Product>()
        .Property(p => p.Name).IsRequired();
        
        builder.Entity<Product>()
        .Property(p => p.Description).HasMaxLength(255);

        builder.Entity<Category>()
        .Property(p => p.Name).IsRequired();
    }


}

