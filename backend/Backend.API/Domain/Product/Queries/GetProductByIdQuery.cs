using Backend.Models;
using MediatR;

namespace Backend.API.Domain.Product.Queries;

public class GetProductByIdQuery : IRequest<ProductEntity>
{
    public Guid ProductId { get; set; }
    public bool ReadOnly { get; set; }
}