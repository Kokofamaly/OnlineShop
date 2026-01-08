namespace OnlineShop.Models.DTOs;

public class OrderItemDTO
{
    public int Id { get; set; }
    public ProductDTO ProductDTO { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Price => Quantity * UnitPrice;

    public OrderItemDTO(
        int id,
        ProductDTO productDTO,
        decimal unitPrice,
        int quantity
    )
    {
        Id = id;
        ProductDTO = productDTO;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

}