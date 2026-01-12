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
    public async Task<IEnumerable<ProductDTO?>> GetAllProducts()
    {
        var products = await _db.Products.Select(p => new ProductDTO(p.Name!, p.Description!, p.Price, p.Stock)).ToListAsync();
        return products;
    }
    public async Task<ProductDTO?> GetProductById(int id)
    {
        Product? product = await _db.Products.FindAsync(id);
        if(product == null) return null;

        return new ProductDTO(product.Name, product.Description, product.Price, product.Stock);
    }
    public async Task<ProductDTO?> AddProduct(Product? product)
    {
        if(product == null) return null;

        ProductDTO productDTO = new ProductDTO(product.Name, product.Description, product.Price, product.Stock);

        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
        return productDTO;
    }
    public async Task<ProductDTO?> DeleteProduct(Product? product)
    {
        if(product == null) return null;

        ProductDTO productDTO = new ProductDTO(product.Name, product.Description, product.Price, product.Stock);

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();

        return productDTO;
    }
    public async Task<ProductDTO?> EditProduct(int id, Product? editedProduct)
    {
        if(editedProduct == null) return null;

        ProductDTO productDTO = new ProductDTO(editedProduct.Name, editedProduct.Description, editedProduct.Price, editedProduct.Stock);

        Product? product = await _db.Products.FindAsync(id);

        if(product == null) return null;

        product.Name = editedProduct.Name;
        product.Description = editedProduct.Description;
        product.Price = editedProduct.Price;
        product.Stock = editedProduct.Stock;

        await _db.SaveChangesAsync();
        return productDTO;

    }
}