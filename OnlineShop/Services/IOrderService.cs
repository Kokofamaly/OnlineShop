using OnlineShop.Models;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Services;

public interface IOrderService
{
    public Task<OrderDTO?> CreateOrderAsync(Guid userId);
    public Task<OrderDTO?> CreateOrderAsync(Guid userId, OrderItem orderItem);
    public Task<OrderDTO?> AddOrderItemAsync(OrderItem orderItem, Order order);
    public Task<OrderDTO?> AddOrderItemAsync(OrderItem orderItem, int orderId, User user);
    public Task<OrderDTO?> DeleteOrderItemAsync(OrderItem orderItem, Order order);
    public Task<OrderDTO?> DeleteOrderItemAsync(OrderItem orderItem, int orderId, User user);
    public Task<IEnumerable<OrderDTO?>> GetAllOrdersAsync(User user);
    public Task<OrderDTO?> GetOrderByIdAsync(int id, User user);

    public Task<OrderDTO?> DeleteOrderAsync(Order order);
    public Task<OrderDTO?> DeleteOrderAsync(int id, User user);

}