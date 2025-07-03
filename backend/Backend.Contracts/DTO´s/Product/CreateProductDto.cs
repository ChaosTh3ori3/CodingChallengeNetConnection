using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.DTO_s.Product;

public class CreateProductDto
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
    public Guid CategoryId { get; set; }

    public string? ImageUrl { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }

    public string? SKU { get; set; }

    public bool IsActive { get; set; } = true;
}