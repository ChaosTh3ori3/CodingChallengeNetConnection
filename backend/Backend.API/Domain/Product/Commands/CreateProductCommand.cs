using Backend.Models;
using MediatR;

namespace Backend.API.Domain.Product.Commands;

public class CreateProductCommand(ProductEntity product) : IRequest<ProductEntity>
{
    public ProductEntity Product => product ?? throw new ArgumentNullException(nameof(product), "Product cannot be null.");
}