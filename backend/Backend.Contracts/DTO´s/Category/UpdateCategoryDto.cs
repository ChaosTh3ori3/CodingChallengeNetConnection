namespace Backend.Contracts.DTO_s.Category;

public class UpdateCategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }
}