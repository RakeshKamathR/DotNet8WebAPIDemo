using DotNet8WebAPIDemo.Models;

namespace DotNet8WebAPIDemo.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync(bool? isActive);

        Task<Product?> GetProductByID(int id);

        Task<Product> AddProduct(AddUpdateProduct obj);

        Task<Product?> UpdateProduct(int id, AddUpdateProduct obj);

        Task<bool> DeleteProductByID(int id);
    }
}
