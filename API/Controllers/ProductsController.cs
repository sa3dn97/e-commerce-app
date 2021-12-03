using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitties;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<product>>> GetProducts()
        {
            var Products = await _repo.GetProductsAsync();
            return Ok(Products);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);

        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());

        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProducTtypes()
        {
            return Ok(await _repo.GetProducttypesAsync());

        }

    }
}