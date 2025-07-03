using Backend.Models;
using Backend.Repository;
using MediatR;

namespace Backend.API.Domain.Product.Commands;

public class CreateProductCommandHandler(
    ILogger<CreateProductCommandHandler> logger,
    ProductManagementDbContext dbContext) : IRequestHandler<CreateProductCommand, ProductEntity>
{
    public async Task<ProductEntity> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating product with ID: {ProductId}", request.Product.Id);

        try
        {
            dbContext.Products.Add(request.Product);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while creating the product with ID: {ProductId}", request.Product.Id);
            throw new InvalidOperationException("Failed to create product.", e);
        }
        logger.LogInformation("Product created successfully with ID: {ProductId}", request.Product.Id);

        return request.Product;
    }
}