namespace OnlineShop.Models.DTOs;

public class ProductDTO
{
    public string? Name { get; }
    public string? Description { get; }
    public decimal Price { get; }
    public int Stock { get; }

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