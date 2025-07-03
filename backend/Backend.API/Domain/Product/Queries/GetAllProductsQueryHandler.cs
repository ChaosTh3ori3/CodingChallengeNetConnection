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
        
        var categoriesQuery = request.ReadOnly
            ? dbContext.ReadAllProductsAsReadOnly()
            : dbContext.ReadAllProducts();
        
        var categories = await categoriesQuery.ToListAsync(cancellationToken: cancellationToken);

        if (categories.Any()) 
            return categories;
        
        logger.LogWarning("No categories found.");
        return [];

    }
}