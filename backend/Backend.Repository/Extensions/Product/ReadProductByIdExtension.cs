using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Extensions.Product;

public static class ReadProductByIdExtension
{
    public static async Task<ProductEntity?> ReadProductByIdAsyncAsReadOnly(this ProductManagementDbContext dbContext, Guid id)
    {
        return await dbContext.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public static async Task<ProductEntity?> ReadProductByIdAsync(this ProductManagementDbContext dbContext, Guid id)
    {
        return await dbContext.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}