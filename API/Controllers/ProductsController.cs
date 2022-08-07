using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public StoreContext _context;
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // return "This will be list of products";
            var products=await _repo.GetProductsAsync();
            return Ok(products);
        }   
        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> GetProduct(int id)
        {   
            // return "single prduct";
            // var product=_context.Products.ToListAsync(id);
            return await _repo.GetProductByIdAsync(id);
        }   
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());

        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());

        }
    }
}