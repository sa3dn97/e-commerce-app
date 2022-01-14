using Core.Entities;
using Core.Entitties;
using Core.Specification;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpec : BaseSpecification<product>
    {
        public ProductWithFiltersForCountSpec(ProductSpecParams productParams)
       : base(x => 
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
                (productParams.Search)) && 
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
            {
                
            }
    }
}