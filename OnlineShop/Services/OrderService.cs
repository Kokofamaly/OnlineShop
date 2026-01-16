using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _db;
    public OrderService(ApplicationDbContext db) => _db = db;

    public async Task<OrderDTO?> CreateOrderAsync(Guid userId)
    {
        Order order = new(userId);
        User user = order.User;
        UserDTO userDTO = new(user.UserName, user.Email, user.Id);

        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();
        
        return new OrderDTO(order.Id, userDTO, order.TotalPrice, await order.OrderItemsListToDto(order.OrderItems));
    }    
    public async Task<OrderDTO?> CreateOrderAsync(Guid userId, OrderItem orderItem)
    {
        Order order = new(userId);
        User user = order.User;
        UserDTO userDTO = new(user.UserName, user.Email, user.Id);
        order.AddItem(orderItem);

        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();
        
        return new OrderDTO(order.Id, userDTO, order.TotalPrice, await order.OrderItemsListToDto(order.OrderItems));
    }
    public async Task<IEnumerable<OrderDTO?>> GetAllOrdersAsync(User user)
    {
        List<Order> orders = await _db.Orders.Where(o => o.UserId == user.Id).ToListAsync();
        List<OrderDTO> orderDTOs = new List<OrderDTO>(orders.Count);
        OrderDTO emptyDto = new(0, null, 0, null);
        foreach (var order in orders)
        {
            orderDTOs.Add(await emptyDto.ToDto(order));
        }

        return orderDTOs;
    }
    public async Task<OrderDTO?> GetOrderByIdAsync(int id, User user){
        Order? order = await _db.Orders.FirstOrDefaultAsync(o => o.User == user && o.Id == id);

        if(order == null) return null;
        OrderDTO emptyDto = new(0, null, 0, null);
        return await emptyDto.ToDto(order);
    }
    public async Task<OrderDTO?> AddOrderItemAsync(OrderItem orderItem, Order order)
    {
        if(orderItem == null || order == null) return null;
        order.AddItem(orderItem);
        OrderDTO emptyDto = new(0, null, 0, null);

        return await emptyDto.ToDto(order);

    }
    public async Task<OrderDTO?> AddOrderItemAsync(OrderItem orderItem, int orderId, User user){
        Order? order = await _db.Orders.FirstOrDefaultAsync(o => o.UserId == user.Id && o.Id == orderId);
        if(orderItem == null || order == null) return null;
        order.AddItem(orderItem);
        OrderDTO emptyDto = new(0, null, 0, null);

        return await emptyDto.ToDto(order);  
    }
    public async Task<OrderDTO?> DeleteOrderItemAsync(OrderItem orderItem, Order order)
    {
        if (order.OrderItems.Remove(orderItem))
        {
        OrderDTO emptyDto = new(0, null, 0, null);
        return await emptyDto.ToDto(order);
        }
        else return null;
    }
    public async Task<OrderDTO?> DeleteOrderItemAsync(OrderItem orderItem, int orderId, User user)
    {
        Order? order = await _db.Orders.FirstOrDefaultAsync(o => o.UserId == user.Id && o.Id == orderId);

        if(orderItem == null || order == null) return null;

        if (order.OrderItems.Remove(orderItem))
        {
        OrderDTO emptyDto = new(0, null, 0, null);
        return await emptyDto.ToDto(order);
        }
        else return null;
    }
    public async Task<OrderDTO?> DeleteOrderAsync(Order order)
    {
        if(order == null) return null;

        OrderDTO emptyDto = new(0, null, 0, null);
        
         _db.Orders.Remove(order);
         await _db.SaveChangesAsync();

         return await emptyDto.ToDto(order);

    }
    public async Task<OrderDTO?> DeleteOrderAsync(int id, User user)
    {
        Order? order = await _db.Orders.FirstOrDefaultAsync(o => o.UserId == user.Id && o.Id == id);

        if(order == null) return null;

        _db.Orders.Remove(order);
        await _db.SaveChangesAsync();

        OrderDTO emptyDto = new(0, null, 0, null);
        return await emptyDto.ToDto(order);
    }
}