using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Services.Interfaces;

namespace WebShoppie.Api.Controllers;


[ApiController]
[Route("products")]
public class ProductController(IProductService service) : ControllerBase
{
    
    [HttpGet]
    public ActionResult<IEnumerable<ProductResponseContract>> GetAll()
    {
        return Ok(service.GetAllProducts());
    }
    
    [HttpGet("{id}")]
    public ActionResult<ProductResponseContract> Get([FromRoute] int id)
    {
        var product = service.GetProduct(id);
        if (product is null)
            return NotFound();
        return Ok(product);
    }
    
    [HttpPost]
    public ActionResult<ProductResponseContract> Create(
        [FromBody] ProductRequestContract productRequestContract)
    {
        var created = service.CreateProduct(productRequestContract);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(
        [FromBody] ProductRequestContract product,
        [FromRoute] int id)
    {
        service.UpdateProduct(product, id);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        service.DeleteProduct(id);
        return NoContent();
    }
}