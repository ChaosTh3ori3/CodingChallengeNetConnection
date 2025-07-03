using Backend.Models;
using Backend.Repository;
using MediatR;

namespace Backend.API.Domain.Category.Commands;

public class CreateCategoryCommandHandler(
    ILogger<CreateCategoryCommandHandler> logger,
    ProductManagementDbContext dbContext) : IRequestHandler<CreateCategoryCommand, CategoryEntity>
{
    public async Task<CategoryEntity> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling CreateCategoryCommand for category: {CategoryName}", request.Category.Name);

        // Validate the request
        if (string.IsNullOrWhiteSpace(request.Category.Name))
        {
            throw new ArgumentException("Category name cannot be null or empty.", nameof(request.Category.Name));
        }

        // Add the new category to the database
        try
        {
            dbContext.Categories.Add(request.Category);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while creating the category: {CategoryName}", request.Category.Name);
            throw new InvalidOperationException("Failed to create category.", e);
        }

        logger.LogInformation("Category created successfully with ID: {CategoryId}", request.Category.Id);

        return request.Category;
    }
}