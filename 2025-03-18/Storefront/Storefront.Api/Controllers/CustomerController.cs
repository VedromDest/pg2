using Microsoft.AspNetCore.Mvc;
using Storefront.Api.Contracts;
using Storefront.Services;

namespace Storefront.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(ICustomerService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CustomerResponseContract>> GetAll()
    {
        return Ok(service.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<CustomerResponseContract> Get([FromRoute] int id)
    {
        var customer = service.GetById(id);
        if (customer is null) return NotFound();
        return Ok();
    }
    
    [HttpPost]
    public ActionResult<CustomerResponseContract> Create(
        [FromBody] CustomerRequestContract customerRequestContract)
    {
        var created = service.Create(customerRequestContract);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public ActionResult Update(
        [FromBody] CustomerRequestContract customer,
        [FromRoute] int id)
    {
        service.Update(id, customer);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Update([FromRoute] int id)
    {
        service.Delete(id);
        return NoContent();
    }
}