using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts.Customers;
using WebShoppie.Domain.Services;
using WebShoppie.Domain.Services.Interfaces;

namespace WebShoppie.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CustomerResponseContract>> CreateCustomer([FromBody]CustomerRequestContract customerToCreate)
    {
        var result = await customerService.CreateCustomerAsync(customerToCreate);

        return result.Match(
            customerResponseContract => CreatedAtAction(nameof(GetById), 
                new { Id = customerResponseContract.CustomerId }, customerResponseContract),
            emailInUseResult => Problem(emailInUseResult.Email, 
                emailInUseResult.Email, 
                statusCode: (int)HttpStatusCode.BadRequest),
            allowedResult => Problem(detail: "country not allowed",  
                statusCode: (int)HttpStatusCode.Unauthorized));
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












