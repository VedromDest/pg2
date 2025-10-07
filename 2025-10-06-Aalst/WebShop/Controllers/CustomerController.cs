using Microsoft.AspNetCore.Mvc;
using WebShop.Contracts;
using WebShop.Services;

namespace WebShop.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController(ICustomerService service) : ControllerBase
{
    //TODO Create CustomerService and refactor this controller
    
    [HttpPost]
    public IActionResult CreateCustomer(CustomerRequestContract customer)
    {
        var createdId = service.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetCustomer), new { customerId = createdId }, null);
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        return Ok(service.GetAll());
    }
    
    
    [HttpGet("{customerId}")]
    public IActionResult GetCustomer([FromRoute] Guid customerId)
    {
        var customer = service.GetById(customerId);

        if (customer is null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPut("{customerId}")]
    public CustomerResponseContract UpdateCustomer(
        [FromRoute] Guid customerId, 
        [FromBody] CustomerRequestContract customer)
    {
        return service.Update(customer, customerId);
    }
    
    [HttpDelete("{customerId}")]
    public void DeleteCustomer([FromRoute] Guid customerId)
    {
        service.Delete(customerId);
    }
}