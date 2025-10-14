using Microsoft.AspNetCore.Mvc;
using WebShopGent.Repositories;
using WebShoppie.Api.Contracts;

namespace WebShoppie.Api.Controllers;

//TODO Klasse laten compileren - build action staat momenteel op 'None'
//TODO Api Controller moet steunen op een ProductService, niet repo
//TODO Alle operaties testen.

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