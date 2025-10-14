using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Services.Interfaces;
using WebShoppie.Persistence.Exceptions;

namespace WebShoppie.Api.Controllers;

// TODO Alles operaties testen

[ApiController]
[Route("customers")]
public class CustomerController(ICustomerService service) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateCustomer(CustomerRequestContract customerToCreate)
    {
        var createdCustomer = service.CreateCustomer(customerToCreate);
        return CreatedAtAction(nameof(GetCustomer),new { customerId = createdCustomer.Id}, createdCustomer);
    }
    
    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        return Ok(service.GetAllCustomers());
    }

    [HttpGet("{customerId}")]
    public IActionResult GetCustomer([FromRoute] int customerId)
    {
        var customer = service.GetCustomer(customerId);

        if (customer is null)
            return NotFound();
        return Ok(customer);
    }

    [HttpPut("{customerId}")]
    public CustomerResponseContract UpdateCustomer([FromBody] CustomerRequestContract customerToUpdate, [FromRoute] int customerId)
    {
        var updated = service.UpdateCustomer(customerToUpdate, customerId);
        return updated;
    }

    [HttpDelete("{customerId}")]
    public IActionResult DeleteCustomer(int customerId)
    {
        try
        {
            service.DeleteCustomer(customerId);
        }
        catch (CustomerNotFoundException cnfe)
        {
            return BadRequest(new ProblemDetails
            {
                Status = (int) HttpStatusCode.BadRequest,
                Title = cnfe.Message
            });
        }
        return Ok();
    }
}