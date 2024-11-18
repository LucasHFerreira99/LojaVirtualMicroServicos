using LojaVirtual.ProductApi.DTOs;
using LojaVirtual.ProductApi.Roles;
using LojaVirtual.ProductApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productsDto = await _productService.GetProducts();
            if (productsDto is null)
                return NotFound("Products not found");

            return Ok(productsDto);
        }

        [HttpGet("{id:int}", Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get(int id)
        {
            var product = await _productService.GetProductsById(id);
            if (product is null)
                return NotFound("Product not found");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productsDto)
        {
            if (productsDto is null)
                return BadRequest("Invalid Data");

            await _productService.AddProduct(productsDto);

            return new CreatedAtRouteResult("GetProducts", new { id = productsDto.Id }, productsDto);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] ProductDTO productsDto)
        {
            if (productsDto is null)
                return BadRequest();

            await _productService.UpdateProduct(productsDto);
            return Ok(productsDto);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(int id)
        {
            var productsDto = await _productService.GetProductsById(id);
            if (productsDto == null)
                return NotFound("Product not found");

            await _productService.RemoveProduct(id);
            return Ok(productsDto);
        }
    }
}
