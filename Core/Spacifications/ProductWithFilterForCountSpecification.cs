using System;
using System.Collections.Generic;
using System.Text;
using Core.Entitties;
using Core.Spacifications;

namespace Core.Specification
{
    public class ProductWithFilterForCountSpecification : BaseSpacifications<product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productParams) 
            : base(x => 
            (String.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
        {
            
        }
    }
}
