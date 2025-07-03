using Backend.Models;
using Backend.Repository;
using Backend.Repository.Extensions.Product;
using MediatR;

namespace Backend.API.Domain.Product.Queries;

public class GetProductByIdQueryHandler(
    ILogger<GetProductByIdQueryHandler> logger,
    ProductManagementDbContext dbContext
    ) : IRequestHandler<GetProductByIdQuery, ProductEntity>
{
    public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetProductByIdQuery for ProductId: {ProductId}", request.ProductId);
        
        var product = request.ReadOnly
            ? await dbContext.ReadProductByIdAsync(request.ProductId)
            : await dbContext.ReadProductByIdAsyncAsReadOnly(request.ProductId);

        if (product == null)
        {
            logger.LogWarning("Product with ID {ProductId} not found", request.ProductId);
            throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
        }

        return product;
    }
}