using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Extensions.Product;

public static class ReadAllProductsExtension
{
    public static IQueryable<ProductEntity> ReadAllProducts(this ProductManagementDbContext dbContext)
    {
        return dbContext.Products
            .Include(p => p.Category);
    }
    
    public static IQueryable<ProductEntity> ReadAllProductsAsReadOnly(this ProductManagementDbContext dbContext)
    {
        return dbContext.Products
            .Include(p => p.Category)
            .AsNoTracking();
    }

    public static async Task<int> ReadAllProductsCount(this ProductManagementDbContext dbContext)
    {
        return await dbContext.ReadAllProductsAsReadOnly().CountAsync();
    }
}