using Microsoft.AspNetCore.Mvc;
using Storefront.Api.Contracts;
using Storefront.Api.Services;

namespace Storefront.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IProductService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ProductResponseContract>> GetAll()
    {
        return Ok(service.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<ProductResponseContract> Get([FromRoute] int id)
    {
        var fetched = service.GetById(id);

        if(fetched == null)
            return NotFound();

        return Ok(fetched);
    }
    
    [HttpPost]
    public ActionResult<ProductResponseContract> Create(
        [FromBody] ProductRequestContract productRequestContract)
    {
        var created = service.Create(productRequestContract);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(
        [FromBody] ProductRequestContract product,
        [FromRoute] int id)
    {
        service.Update(id, product);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        try
        {
            service.Delete(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return NoContent();
    }
}