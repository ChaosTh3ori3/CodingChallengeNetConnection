using Backend.Models;
using MediatR;

namespace Backend.API.Domain.Category.Commands;

public class CreateCategoryCommand(CategoryEntity category) : IRequest<CategoryEntity>
{
    public CategoryEntity Category => category ?? throw new ArgumentNullException(nameof(category), "Category cannot be null.");
}
