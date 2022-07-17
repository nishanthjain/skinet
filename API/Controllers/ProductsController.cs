using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // return "This will be list of products";
            var products=_context.Products.ToListAsync();
            return Ok(products);
        }   
        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // return "single prduct";
            // var product=_context.Products.ToListAsync(id);
            return await _context.Products.FindAsync(id);
        }
    }
}