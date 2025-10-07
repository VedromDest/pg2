using Microsoft.AspNetCore.Mvc;
using WebShopGent.Contracts;
using WebShopGent.Repositories;

namespace WebShopGent.Controllers;

[ApiController]
[Route("products")]
public class ProductController(IProductRepository repository) : ControllerBase
{
    
    [HttpGet]
    public ActionResult<IEnumerable<ProductResponseContract>> GetAll()
    {
        return Ok(repository.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<ProductResponseContract> Get([FromRoute] Guid id)
    {
        var product = repository.Get(id);
        if (product is null)
            return NotFound();
        return Ok(product);
    }
    
    [HttpPost]
    public ActionResult<ProductResponseContract> Create(
        [FromBody] ProductRequestContract productRequestContract)
    {
        var created = repository.Create(productRequestContract);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(
        [FromBody] ProductRequestContract product,
        [FromRoute] Guid id)
    {
        repository.Update(product, id);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Update([FromRoute] Guid id)
    {
        repository.Delete(id);
        return NoContent();
    }
}