using DotNet8WebAPIDemo.Entity;
using DotNet8WebAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebAPIDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _productList;
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public async Task<Product> AddProduct(AddUpdateProduct obj)
        {
            var addProduct = new Product()
            {
                ProductName = obj.ProductName,
                tags = obj.tags,
                isActive = obj.isActive,
            };

            await _context.Products.AddAsync(addProduct);
            await _context.SaveChangesAsync();

            return addProduct;
        }

        public async Task<bool> DeleteProductByID(int id)
        {
            var productIndex =await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            if (productIndex!=null)
            {
                _context.Remove(productIndex);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Product>> GetAllProductsAsync(bool? isActive)
        {
            
            if (isActive == null) { return await _context.Products.ToListAsync(); }

            return await _context.Products.Where(obj => obj.isActive == isActive).ToListAsync();

        }

        public async Task<Product>? GetProductByID(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<Product?> UpdateProduct(int id, AddUpdateProduct obj)
        {
            var product =await _context.Products.FindAsync(id);
            if (product==null)
            { 
                return null;
            }
            product.ProductName = obj.ProductName;
            product.tags = obj.tags;
            product.isActive = obj.isActive;

            await _context.SaveChangesAsync();
            return product;
        }
    }
}
