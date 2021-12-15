using System;
using System.Linq.Expressions;
using Core.Entitties;
using Core.Specification;

namespace Core.Spacifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpacifications<product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productprams)
            :base(x =>
                (String.IsNullOrEmpty(productprams.Search) || x.Name.ToLower().Contains(productprams.Search)) &&
                (!productprams.BrandId.HasValue || x.ProductBrandId == productprams.BrandId) && 
                (!productprams.TypeId.HasValue || x.ProductTypeId == productprams.TypeId)
            
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOredrBy(x => x.Name);
            ApplyPaging(productprams.PageSize*(productprams.PageIndex-1),productprams.PageSize );
            if (!String.IsNullOrEmpty(productprams.Sort))
            {
                switch(productprams.Sort)
                {
                    case"priceAsc":
                        AddOredrBy( p => p.Price);
                        break;
                    case"priceDesc":
                        AddOrderByDecending(p => p.Price);
                        break;
                    default:
                        AddOredrBy(n => n.Name);
                        break;

                 }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id)
         : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}