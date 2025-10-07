using Microsoft.AspNetCore.Mvc;
using Storefront.Api.Contracts;
using Storefront.Api.Repositories;

namespace Storefront.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IProductRepository repository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ProductResponseContract>> GetAll()
    {
        return Ok(repository.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<ProductResponseContract> Get([FromRoute] int id)
    {
        return Ok(repository.Get(id));
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
        [FromRoute] int id)
    {
        repository.Update(product, id);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Update([FromRoute] int id)
    {
        repository.Delete(id);
        return NoContent();
    }
}