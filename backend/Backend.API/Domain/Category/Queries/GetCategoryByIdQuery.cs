using Backend.Models;
using MediatR;

namespace Backend.API.Domain.Category.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryEntity>
{
    public Guid CategoryId { get; set; }
    
    public  bool ReadOnly { get; set; }
}
