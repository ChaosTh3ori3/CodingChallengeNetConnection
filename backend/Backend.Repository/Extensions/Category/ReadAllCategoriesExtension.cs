using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Extensions.Category;

public static class ReadAllCategoriesExtension
{
    public static IQueryable<CategoryEntity> ReadAllCategories(this ProductManagementDbContext dbContext)
    {
        return dbContext.Categories;
    }
    
    public static IQueryable<CategoryEntity> ReadAllCategoriesAsReadOnly(this ProductManagementDbContext dbContext)
    {
        return dbContext.Categories
            .AsNoTracking();
    }

    public static async Task<int> ReadAllCategoriesCount(this ProductManagementDbContext dbContext)
    {
        return await dbContext.ReadAllCategoriesAsReadOnly().CountAsync();
    }
}