using OnlineShop.Data;
using OnlineShop.Models.DTOs;

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

    public async Task<List<OrderItemDTO>> OrderItemsListToDto(List<OrderItem> orderItems)
    {
        List<OrderItemDTO> orderItemDTOs = new List<OrderItemDTO>(orderItems.Count);
        foreach(OrderItem orderItem in orderItems)
        {
            orderItemDTOs.Add(new(
                orderItem.Id, 
                new ProductDTO(orderItem.Product.Name, orderItem.Product.Description, orderItem.Product.Price, orderItem.Product.Stock), 
                orderItem.UnitPrice, 
                orderItem.Quantity
            ));
        }

        return orderItemDTOs;
    }
}
