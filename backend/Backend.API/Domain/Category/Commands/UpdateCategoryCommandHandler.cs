using Backend.Models;
using Backend.Repository;
using MediatR;

namespace Backend.API.Domain.Category.Commands;

public class UpdateCategoryCommandHandler(
    ILogger<UpdateCategoryCommandHandler> logger,
    ProductManagementDbContext dbContext) : IRequestHandler<UpdateCategoryCommand, CategoryEntity>
{
    public async Task<CategoryEntity> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling UpdateCategoryCommand for category: {CategoryName}", request.Category.Name);

        // Update the existing category in the database
        try
        {
            dbContext.Categories.Update(request.Category);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while updating the category: {CategoryName}", request.Category.Name);
            throw new InvalidOperationException("Failed to update category.", e);
        }

        logger.LogInformation("Category updated successfully with ID: {CategoryId}", request.Category.Id);

        return request.Category;
    }
}