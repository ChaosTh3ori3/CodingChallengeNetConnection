using Backend.Models;
using Backend.Repository;
using Backend.Repository.Extensions.Category;
using MediatR;

namespace Backend.API.Domain.Category.Queries;

public class GetCategoryByIdQueryHandler(
    ILogger<GetCategoryByIdQueryHandler> logger,
    ProductManagementDbContext dbContext) : IRequestHandler<GetCategoryByIdQuery, CategoryEntity>
{
    public async Task<CategoryEntity> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetCategoryByIdQuery for CategoryId: {CategoryId}", request.CategoryId);

        var category = request.ReadOnly
            ? await dbContext.ReadCategoryByIdAsyncAsReadOnly(request.CategoryId)
            : await dbContext.ReadCategoryByIdAsync(request.CategoryId);

        if (category == null)
        {
            logger.LogWarning("Category with ID {CategoryId} not found", request.CategoryId);
            throw new KeyNotFoundException($"Category with ID {request.CategoryId} not found.");
        }

        return category;
    }
}