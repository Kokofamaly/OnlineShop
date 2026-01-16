using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;

namespace OnlineShop.Endpoints;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this WebApplication app)
    {
        app.MapGet("/orders", GetAllOrders).RequireAuthorization();
        app.MapGet("/orders/{id:int}", GetOrderById).RequireAuthorization();
        app.MapPost("/orders/empty", CreateEmptyOrder).RequireAuthorization();
        app.MapPost("/orders", CreateOrder).RequireAuthorization();
        app.MapPost("/orders/orderItem", AddOrderItemToOrder).RequireAuthorization();
        app.MapDelete("/orders", DeleteOrder).RequireAuthorization();
        app.MapDelete("/orders/orderItem", DeleteOrderItem).RequireAuthorization();
    }

    public static async Task<IResult> GetAllOrders(IOrderService service, ClaimsPrincipal user, ApplicationDbContext db)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var orders = await service.GetAllOrdersAsync(await db.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId));

        if(orders == null) return Results.BadRequest();

        return Results.Ok(orders);
    }
    public static async Task<IResult> GetOrderById(IOrderService service, int id, ClaimsPrincipal user, ApplicationDbContext db)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var order = await service.GetOrderByIdAsync(id, await db.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId));
        if(order == null) return Results.NotFound();

        return Results.Ok(order);
    }
    public static async Task<IResult> CreateEmptyOrder(IOrderService service, ClaimsPrincipal user, ApplicationDbContext db)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        User user1 = await db.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

        var order = await service.CreateOrderAsync(user1.Id);
        if(order == null) return Results.BadRequest();

        return Results.Ok(order);
    }
    public static async Task<IResult> CreateOrder(IOrderService service, ClaimsPrincipal user, ApplicationDbContext db, [FromBody] OrderItem orderItem)
    {
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        User user1 = await db.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

        var order = await service.CreateOrderAsync(user1.Id, orderItem);
        if(order == null) return Results.BadRequest();

        return Results.Ok(order);
    }
    public static async Task<IResult> AddOrderItemToOrder(IOrderService service, ApplicationDbContext db, [FromBody] OrderItem orderItem)
    {
       var orderDTO = await service.AddOrderItemAsync(orderItem, await db.Orders.FindAsync(orderItem.OrderId));
       if(orderDTO == null) return Results.BadRequest();

       return Results.Ok(orderDTO);
    }
    public static async Task<IResult> DeleteOrder(IOrderService service, [FromBody] Order order)
    {
        var orderDTO = await service.DeleteOrderAsync(order);
        if(orderDTO == null) return Results.BadRequest();

        return Results.Ok(orderDTO);
    }
    public static async Task<IResult> DeleteOrderItem(IOrderService service, ApplicationDbContext db, [FromBody] OrderItem orderItem)
    {
        var orderDTO = await service.DeleteOrderItemAsync(orderItem, await db.Orders.FindAsync(orderItem.OrderId));
        if(orderDTO == null) return Results.BadRequest();

        return Results.Ok(orderDTO);
    }
    

}