using OnlineShop.Services;
using OnlineShop.Models;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Endpoints;
public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/products", GetAllProducts);
        app.MapGet("/products/{id:int}", GetProductById);
    }

    private static async Task<IResult> GetAllProducts(IProductService service)
    {
        var products = await service.GetAllProducts();
        if(products == null) return Results.NotFound("Problem with products list");

        return Results.Ok(products);
    }

    private static async Task<IResult> GetProductById(IProductService service, int id)
    {
        var product = await service.GetProductById(id);
        if(product == null) return Results.NotFound("Product Not Found.");

        return Results.Ok(product);
    }
}