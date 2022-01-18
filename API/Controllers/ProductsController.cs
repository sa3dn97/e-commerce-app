using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Spacifications;
using Core.Specification;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {

        private readonly IGenericRepository<product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _producttypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<product> productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> producttypeRepo
        , IMapper mapper)
        {
            _mapper = mapper;
            _producttypeRepo = producttypeRepo;
            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery]ProductSpecParams productPrams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productPrams);   
            var countSpec = new ProductWithFiltersForCountSpec(productPrams);
            var totalItems = await _productsRepo.CountAsync(countSpec );
            var Products = await _productsRepo.ListAsync(spec);
            var data = _mapper
                .Map<IReadOnlyList<product>,IReadOnlyList<ProductToReturnDto>>(Products);

            return Ok(new Pagination<ProductToReturnDto>
            (productPrams.PageIndex,productPrams.PageSize,totalItems,data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productsRepo.GetEntityWithSpec(spec);
            if (product == null ) return NotFound(new ApiResponse(404));

            return _mapper .Map<product,ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());

        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProducTtypes()
        {
            return Ok(await _producttypeRepo.ListAllAsync());

        }

    }
}