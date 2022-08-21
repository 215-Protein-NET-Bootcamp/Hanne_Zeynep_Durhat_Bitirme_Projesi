using Bitirme_Projesi_Data.Models;
using Bitirme_Projesi_Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bitirme_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/<ProductController>
        [HttpGet("Color")]
        public IEnumerable<string> GetColor()
        {
            return new string[] { "Blue", "Green", "Purple", "Red", "Yellow", "White" };
        }

        [HttpGet("Brand")]
        public IEnumerable<string> GetBrand()
        {
            return new string[] { "Apple", "Bosch", "Casper", "Dyson", "Samsung" };
        }




        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResponse product)
        {
            try
            {
                var createdCompany = await _productRepository.AddProduct(product);
                return CreatedAtRoute("CompanyById", new { id = createdCompany.ProductId }, product);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

       
    }
}
