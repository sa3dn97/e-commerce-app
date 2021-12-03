using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entitties;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public  async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await  _context.ProductBrands.ToListAsync();
        }

        public async Task<product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<product>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).ToListAsync();
        }

       

        public async Task<IReadOnlyList<ProductType>> GetProducttypesAsync()
        {
            return await  _context.ProductTypes.ToListAsync();
        }
    }
}