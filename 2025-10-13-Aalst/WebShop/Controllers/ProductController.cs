using Microsoft.AspNetCore.Mvc;
using WebShop.Contracts;
using WebShop.Repositories;
using WebShop.Services;

namespace WebShop.Controllers;
//TODO Fix the mess
/*
[ApiController]
[Route("products")]
public class ProductController(IProductService productService) : ControllerBase
{
    
    //TODO Create ProductService and refactor this controller
    
    [HttpGet]
    public ActionResult<IEnumerable<ProductResponseContract>> GetAll()
    {
        return Ok(productService.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<ProductResponseContract> Get([FromRoute] Guid id)
    {
        var product = productService.GetById(id);
        if (product is null)
            return NotFound();
        return Ok(product);
    }
    
    [HttpPost]
    public ActionResult<ProductResponseContract> Create(
        [FromBody] ProductRequestContract productRequestContract)
    {
        var created = productService.CreateProduct(productRequestContract);
        return CreatedAtAction(nameof(Get), new { id = created }, null);
    }

    [HttpPut("{id}")]
    public ActionResult Update(
        [FromBody] ProductRequestContract product,
        [FromRoute] Guid id)
    {
        productService.Update(product, id);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Update([FromRoute] Guid id)
    {
        productService.Delete(id);
        return NoContent();
    }
}
*/