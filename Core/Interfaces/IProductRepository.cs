using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entitties;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProducttypesAsync();
     

    }
}