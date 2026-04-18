using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts.Products;
using WebShoppie.Domain.Services.Interfaces;

namespace WebShoppie.Api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ProductResponseContract>> CreateProduct([FromBody] ProductRequestContract productToCreate)
    {
        var created = await productService.CreateProductAsync(productToCreate);

        return Ok(created);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseContract>> GetById([FromRoute]int id)
    {
        var product = await productService.GetProductByIdAsync(id);
        if (product is null)
            return NotFound();
        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductResponseContract>>> GetAll()
    {
        return Ok(await productService.GetAllProductsAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ProductRequestContract contract)
    {
        await productService.UpdateProductAsync(id, contract);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await productService.DeleteProductAsync(id);
        return NoContent();
    }        
}