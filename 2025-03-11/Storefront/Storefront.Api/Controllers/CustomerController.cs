using Microsoft.AspNetCore.Mvc;
using Storefront.Api.Contracts;
using Storefront.Api.Repositories;

namespace Storefront.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(ICustomerRepository repository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CustomerResponseContract>> GetAll()
    {
        return Ok(repository.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<CustomerResponseContract> Get([FromRoute] int id)
    {
        return Ok(repository.Get(id));
    }
    
    [HttpPost]
    public ActionResult<CustomerResponseContract> Create(
        [FromBody] CustomerRequestContract customerRequestContract)
    {
        var created = repository.Create(customerRequestContract);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(
        [FromBody] CustomerRequestContract customer,
        [FromRoute] int id)
    {
        repository.Update(customer, id);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Update([FromRoute] int id)
    {
        repository.Delete(id);
        return NoContent();
    }
}