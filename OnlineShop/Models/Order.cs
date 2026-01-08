using OnlineShop.Data;

namespace OnlineShop.Models;

public class Order
{
    public int Id { get; private set; }
    public Guid UserId { get; private set; }
    public User? User { get; private set; }  // навигация
    public decimal TotalPrice => OrderItems.Sum(oi => oi.Price); 
    public List<OrderItem> OrderItems { get; private set; } = new();

    protected Order() {} // для EF Core

    public Order(Guid userId)
    {
        UserId = userId;
    }

    public void AddItem(OrderItem item)
    {
        OrderItems.Add(item);
    }
}
