using Backend.Models;
using MediatR;

namespace Backend.API.Domain.Category.Commands;

public class DeleteCategoryCommand(Guid id) : IRequest<CategoryEntity>
{
    public Guid CategoryId => id;
}