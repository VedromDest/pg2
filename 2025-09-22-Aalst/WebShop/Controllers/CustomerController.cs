using Microsoft.AspNetCore.Mvc;
using WebShop.Contracts;
using WebShop.Repositories;

namespace WebShop.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController(CustomerRepository repository) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateCustomer(CustomerRequestContract customer)
    {
        var createdId = repository.Add(customer);
        return CreatedAtAction(nameof(GetCustomer), new { customerId = createdId }, null);
    }
    
    [HttpGet("{customerId}")]
    public CustomerResponseContract GetCustomer([FromRoute] Guid customerId)
    {
        return repository.Read(customerId);
    }
}