using Backend.Models;
using MediatR;

namespace Backend.API.Domain.Product.Commands;

public class DeleteProductCommand(Guid productId) : IRequest<ProductEntity>
{
    public Guid ProductId => productId;
}