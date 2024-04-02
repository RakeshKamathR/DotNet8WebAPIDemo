using Asp.Versioning;
using DotNet8WebAPIDemo.Helpers;
using DotNet8WebAPIDemo.Models;
using DotNet8WebAPIDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebAPIDemo.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion(1, Deprecated = true)]
    [ApiVersion(2)]
    [Route("api/v{v:apiVersion}/[controller]")]
    
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? isActive = null)
        {
            return Ok(await _productService.GetAllProductsAsync(isActive));
        }

        [MapToApiVersion(1)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetV1(int id)
        {
            var hero =await _productService.GetProductByID(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [MapToApiVersion(2)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetV2(int id)
        {
            var hero = await _productService.GetProductByID(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUpdateProduct productObject)
        {
            var product =await _productService.AddProduct(productObject);

            if (product == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Product Added Successfully!!!",
                id = product!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdateProduct productObject)
        {
            var product =await _productService.UpdateProduct(id, productObject);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Product Updated Successfully!!!",
                id = product!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _productService.DeleteProductByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Product Deleted Successfully!!!",
                id = id
            });
        }
    }
}
