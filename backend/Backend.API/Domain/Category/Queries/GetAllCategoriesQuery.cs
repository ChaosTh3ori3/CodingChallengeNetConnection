using Backend.Models;
using MediatR;

namespace Backend.API.Domain.Category.Queries;

public class GetAllCategoriesQuery : IRequest<List<CategoryEntity>>
{
    public bool ReadOnly { get; set; }
}
