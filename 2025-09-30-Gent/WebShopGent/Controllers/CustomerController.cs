using Microsoft.AspNetCore.Mvc;
using WebShopGent.Contracts;
using WebShopGent.Repositories;

namespace WebShopGent.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateCustomer(CustomerRequestContract customerToCreate)
    {
        var createdCustomer = customerRepository.SaveCustomer(customerToCreate);
        return CreatedAtAction(nameof(GetCustomer),new { customerId = createdCustomer.Id}, createdCustomer);
    }
    
    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        return Ok(customerRepository.GetAllCustomers());
    }

    [HttpGet("{customerId}")]
    public IActionResult GetCustomer([FromRoute] Guid customerId)
    {
        var customer = customerRepository.GetCustomer(customerId);

        if (customer is null)
            return NotFound();
        return Ok(customer);
    }

    [HttpPut("{customerId}")]
    public CustomerResponseContract UpdateCustomer([FromBody] CustomerRequestContract customerToUpdate, [FromRoute] Guid customerId)
    {
        var updated = customerRepository.UpdateCustomer(customerToUpdate, customerId);
        return updated;
    }

    [HttpDelete("{customerId}")]
    public IActionResult DeleteCustomer(Guid customerId)
    {
        customerRepository.Delete(customerId);
        return Ok();
    }
}