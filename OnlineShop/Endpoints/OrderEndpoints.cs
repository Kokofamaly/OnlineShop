using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Models;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;

namespace OnlineShop.Endpoints;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this WebApplication app)
    {
        app.MapGet("/orders", GetAllOrders);
        app.MapGet("/orders/{id:int}", GetOrderById);
        app.MapPost("/orders/empty", CreateEmptyOrder).RequireAuthorization();
        app.MapPost("/orders", CreateOrder).RequireAuthorization();
        app.MapPost("/orders/orderItem", AddOrderItemToOrder).RequireAuthorization();
        app.MapDelete("/orders", DeleteOrder).RequireAuthorization();
        app.MapDelete("/orders/orderItem", DeleteOrderItem).RequireAuthorization();
    }

    public static async Task<IResult> GetAllOrders(IOrderService service, ClaimsPrincipal user)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var orders = await service.GetAllOrdersAsync();

        if(orders == null) return Results.BadRequest();

        return Results.Ok(orders);
    }
    public static async Task<IResult> GetOrderById(IOrderService service, int id, User user)
    {
        var order = await service.GetOrderByIdAsync(id, user);
        if(order == null) return Results.NotFound();

        return Results.Ok(order);
    }
    public static async Task<IResult> CreateEmptyOrder(IOrderService service, Guid userId)
    {
        var order = await service.CreateOrderAsync(userId);
        if(order == null) return Results.BadRequest();

        return Results.Ok(order);
    }
    public static async Task<IResult> CreateOrder(IOrderService service, Guid userId, OrderItem orderItem)
    {
        var order = await service.CreateOrderAsync(userId, orderItem);
        if(order == null) return Results.BadRequest();

        return Results.Ok(order);
    }
    public static async Task<IResult> AddOrderItemToOrder(IOrderService service, OrderItem orderItem, Order order)
    {
       var orderDTO = await service.AddOrderItemAsync(orderItem, order);
       if(orderDTO == null) return Results.BadRequest();

       return Results.Ok(orderDTO);
    }
    public static async Task<IResult> DeleteOrder(IOrderService service, Order order)
    {
        var orderDTO = await service.DeleteOrderAsync(order);
        if(orderDTO == null) return Results.BadRequest();

        return Results.Ok(orderDTO);
    }
    public static async Task<IResult> DeleteOrderItem(IOrderService service, OrderItem orderItem, Order order)
    {
        var orderDTO = await service.DeleteOrderItemAsync(orderItem, order);
        if(orderDTO == null) return Results.BadRequest();

        return Results.Ok(orderDTO);
    }
    

}