using Microsoft.AspNetCore.Mvc;
using WebShopGent.Contracts;
using WebShopGent.Repositories;

namespace WebShopGent.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController(CustomerRepository customerRepository) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateCustomer(CustomerRequestContract customerToCreate)
    {
        var createdCustomer = customerRepository.SaveCustomer(customerToCreate);
        return CreatedAtAction(nameof(GetCustomer),new { customerId = createdCustomer.Id}, createdCustomer);
    }

    [HttpGet("{customerId}")]
    public CustomerResponseContract GetCustomer([FromRoute] Guid customerId)
    {
        return customerRepository.GetCustomer(customerId);
    }
}