using Backend.Models;
using Backend.Repository;
using Backend.Repository.Extensions.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Domain.Category.Queries;

public class GetAllCategoriesQueryHandler(
    ILogger<GetAllCategoriesQueryHandler> logger,
    ProductManagementDbContext dbContext) : IRequestHandler<GetAllCategoriesQuery, List<CategoryEntity>>
{
    public async Task<List<CategoryEntity>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        logger.LogDebug("Retrieving all categories with ReadOnly set to {ReadOnly}.", request.ReadOnly);
        
        var categoriesQuery = request.ReadOnly
            ? dbContext.ReadAllCategoriesAsReadOnly()
            : dbContext.ReadAllCategories();
        
        var categories = await categoriesQuery.ToListAsync(cancellationToken: cancellationToken);

        if (categories.Any())
            return categories;
        
        logger.LogWarning("No categories found.");
        return [];

    }
}