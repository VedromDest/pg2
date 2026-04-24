using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts.Customers;
using WebShoppie.Domain.Services.Interfaces;

namespace WebShoppie.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CustomerResponseContract>> CreateCustomer([FromBody]CustomerRequestContract customerToCreate)
    {
        var created = await customerService.CreateCustomerAsync(customerToCreate);

        return CreatedAtAction(nameof(GetById), new { Id = created.CustomerId }, created);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerResponseContract>> GetById([FromRoute]int id)
    {
        var customer = await customerService.GetCustomerByIdAsync(id);
        if (customer is null)
            return NotFound();
        return Ok(customer);
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerResponseContract>>> GetAll()
    {
        return Ok(await customerService.GetAllAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CustomerRequestContract contract)
    {
        if (await customerService.UpdateAsync(id, contract))
            return NoContent();
        return NotFound();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await customerService.DeleteAsync(id);
        return NoContent();
    }    
}












