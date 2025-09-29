using Microsoft.AspNetCore.Mvc;
using WebShop.Contracts;
using WebShop.Repositories;

namespace WebShop.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController(CustomerRepository repository) : ControllerBase
{
    //TODO Create CustomerService and refactor this controller
    
    [HttpPost]
    public IActionResult CreateCustomer(CustomerRequestContract customer)
    {
        var createdId = repository.Add(customer);
        return CreatedAtAction(nameof(GetCustomer), new { customerId = createdId }, null);
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        return Ok(repository.ReadAll());
    }
    
    
    [HttpGet("{customerId}")]
    public IActionResult GetCustomer([FromRoute] Guid customerId)
    {
        var customer = repository.Read(customerId);

        if (customer is null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPut("{customerId}")]
    public CustomerResponseContract UpdateCustomer(
        [FromRoute] Guid customerId, 
        [FromBody] CustomerRequestContract customer)
    {
        return repository.Update(customer, customerId);
    }
    
    [HttpDelete("{customerId}")]
    public void DeleteCustomer([FromRoute] Guid customerId)
    {
        repository.Delete(customerId);
    }
}