using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _db;

    public ProductService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        var products = await _db.Products.Select(p => new ProductDTO(p.Name!, p.Description!, p.Price, p.Stock)).ToListAsync();
        return products;
    }
    public async Task<ProductDTO> GetProductById(int id)
    {
        Product? product = await _db.Products.FindAsync(id);
        return new ProductDTO(product.Name, product.Description, product.Price, product.Stock);
    }
    public async Task<ProductDTO> AddProduct(Product? product){}
    public async Task<ProductDTO> DeleteProduct(Product? product){}
    public async Task<ProductDTO> EditProduct(Product? product){}
}