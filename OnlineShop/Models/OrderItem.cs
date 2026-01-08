namespace OnlineShop.Models;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

     public decimal Price => Quantity * UnitPrice;


    public OrderItem(){}

    public OrderItem(Product product, int quantity = 1)
    {
        UnitPrice = product.Price;
        ProductId = product.Id;
        Quantity = quantity;
        Product = product;
    }

}