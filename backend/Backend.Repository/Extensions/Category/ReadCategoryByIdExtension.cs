using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Extensions.Category;

public static class ReadCategoryByIdExtension
{
    public static async Task<CategoryEntity?> ReadCategoryByIdAsyncAsReadOnly(this ProductManagementDbContext dbContext, Guid id)
    {
        return await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public static async Task<CategoryEntity?> ReadCategoryByIdAsync(this ProductManagementDbContext dbContext, Guid id)
    {
        return await dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}