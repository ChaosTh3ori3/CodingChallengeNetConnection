using Backend.Models;
using MediatR;

namespace Backend.API.Domain.Product.Queries;

public class GetAllProductsQuery : IRequest<List<ProductEntity>>
{
    public bool ReadOnly { get; set; }
}