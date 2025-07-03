using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class ProductEntity : BaseEntity
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public CategoryEntity Category { get; set; }

    public string? ImageUrl { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; } = 0;

    public string? SKU { get; set; } // Stock Keeping Unit

    public bool IsActive { get; set; } = true;
}