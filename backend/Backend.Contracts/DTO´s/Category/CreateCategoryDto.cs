using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.DTO_s.Category;

public class CreateCategoryDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }
}