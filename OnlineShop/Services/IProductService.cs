using OnlineShop.Models;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Services;

public interface IProductService
{
    public Task<IEnumerable<ProductDTO?>> GetAllProducts();
    public Task<ProductDTO?> GetProductById(int id);
    public Task<ProductDTO?> AddProduct(Product? product);
    public Task<ProductDTO?> DeleteProduct(Product? product);
    public Task<ProductDTO?> EditProduct(int id, Product? editedProduct);
}