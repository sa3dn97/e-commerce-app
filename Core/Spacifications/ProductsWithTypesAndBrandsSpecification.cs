using System;
using System.Linq.Expressions;
using Core.Entitties;
using Core.Specification;
using Core.Specifications;

namespace Core.Spacifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<product>
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
            AddOrderBy(x => x.Name);
            ApplyPaging(productprams.PageSize*(productprams.PageIndex-1),productprams.PageSize );
            if (!String.IsNullOrEmpty(productprams.Sort))
            {
                switch(productprams.Sort)
                {
                    case"priceAsc":
                        AddOrderBy( p => p.Price);
                        break;
                    case"priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
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