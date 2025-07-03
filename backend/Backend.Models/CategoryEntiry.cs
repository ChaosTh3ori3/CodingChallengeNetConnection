using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class CategoryEntity: BaseEntity
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }
}