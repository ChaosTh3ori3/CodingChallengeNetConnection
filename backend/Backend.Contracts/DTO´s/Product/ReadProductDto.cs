using Backend.Contracts.DTO_s.Category;

namespace Backend.Contracts.DTO_s.Product;

public class ReadProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public ReadCategoryDto? Category { get; set; }

    public string? ImageUrl { get; set; }

    public int StockQuantity { get; set; }

    public string? SKU { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}