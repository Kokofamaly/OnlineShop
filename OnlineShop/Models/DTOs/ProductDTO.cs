namespace OnlineShop.Models.DTOs;

public class ProductDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public ProductDTO(
        string name,
        string description,
        decimal price,
        int stock
    )
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }
}