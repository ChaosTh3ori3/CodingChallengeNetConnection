using Backend.Models;
using Backend.Repository;
using Backend.Repository.Extensions.Product;
using MediatR;

namespace Backend.API.Domain.Product.Commands;

public class DeleteProductCommandHandler(
    ILogger<DeleteProductCommandHandler> logger,
    ProductManagementDbContext dbContext) : IRequestHandler< DeleteProductCommand, ProductEntity>
{
    public async Task<ProductEntity> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling DeleteProductCommand for product ID: {ProductId}", request.ProductId);

        // Find the product in the database
        var product = await dbContext.ReadProductByIdAsyncAsReadOnly(request.ProductId);
        if (product == null)
        {
            logger.LogWarning("Product with ID: {ProductId} not found.", request.ProductId);
            throw new KeyNotFoundException($"Product with ID: {request.ProductId} not found.");
        }

        // Remove the product from the database
        try
        {
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while deleting the product with ID: {ProductId}", request.ProductId);
            throw new InvalidOperationException("Failed to delete product.", e);
        }

        logger.LogInformation("Product with ID: {ProductId} deleted successfully.", request.ProductId);

        return product;
    }
}