using Catalog.Api.Entities;
using Catalog.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ProductsController(IProductRepository productRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await productRepository.ProductsList();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(string id)
        {
            var products = await productRepository.GetProduct(id);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var products = await productRepository.UpdateProduct(product);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(Product product)
        {
            await productRepository.InsertProduct(product);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result =  await productRepository.DeleteProduct(id);
            return Ok(result);
        }
    }
}
