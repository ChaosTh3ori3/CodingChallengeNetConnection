using Backend.Models;
using Backend.Repository;
using Backend.Repository.Extensions.Category;
using MediatR;

namespace Backend.API.Domain.Category.Commands;

public class DeleteCategoryCommandHandler(
    ILogger<DeleteCategoryCommandHandler> logger,
    ProductManagementDbContext dbContext) : IRequestHandler<DeleteCategoryCommand, CategoryEntity>
{
    public async Task<CategoryEntity> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling DeleteCategoryCommand for category: {CategoryId}", request.CategoryId);

        // Check if the category exists
        var existingCategory = await dbContext.ReadCategoryByIdAsyncAsReadOnly(request.CategoryId);
        if (existingCategory == null)
        {
            throw new KeyNotFoundException($"Category with ID {request.CategoryId} not found.");
        }

        // Remove the category from the database
        try
        {
            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while deleting the category: {CategoryName}", existingCategory.Name);
            throw new InvalidOperationException("Failed to delete category.", e);
        }

        logger.LogInformation("Category deleted successfully with ID: {CategoryId}", request.CategoryId);

        return existingCategory;
    }
}