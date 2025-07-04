using Backend.Models;
using Backend.Repository;
using Backend.Repository.Extensions.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Domain.Product.Queries;

public class GetAllProductsQueryHandler(
    ILogger<GetAllProductsQueryHandler> logger,
    ProductManagementDbContext dbContext) : IRequestHandler<GetAllProductsQuery, List<ProductEntity>>
{
    public async Task<List<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogDebug("Retrieving all products with ReadOnly set to {ReadOnly}.", request.ReadOnly);
        
        var productsQuery = request.ReadOnly
            ? dbContext.ReadAllProductsAsReadOnly()
            : dbContext.ReadAllProducts();

        var products = await productsQuery.ToListAsync(cancellationToken: cancellationToken);

        if (products.Any())
            return products;

        logger.LogWarning("No products found.");
        return [];

    }
}