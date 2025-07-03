namespace Backend.Contracts.DTO_s.Category;

public class ReadCategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}