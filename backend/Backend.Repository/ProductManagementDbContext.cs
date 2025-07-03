using Backend.Models;
using Backend.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) : DbContext(options)
{

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Category
        modelBuilder.SetChangeTrackedEntityAndId<CategoryEntity>();
        
        modelBuilder.Entity<CategoryEntity>()
            .HasIndex(c => c.Name)
            .IsUnique();
        
        // Product
        modelBuilder.SetChangeTrackedEntityAndId<ProductEntity>();

        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    public override int SaveChanges()
    {
        this.SetAuditFields();
        return base.SaveChanges();
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.SetAuditFields();
        return await base.SaveChangesAsync(cancellationToken);
    }
}