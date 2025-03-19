using Microsoft.AspNetCore.Mvc;
using TreinAbonnementen.Api.Contracts;
using TreinAbonnementen.Service;

namespace TreinAbonnementen.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(ICustomerService service) : ControllerBase
{
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(service.GetAll());
    }
    
    [HttpGet("{id:int}")]
    public IActionResult Get([FromRoute] int id)
    {
        var contract = service.GetById(id);
        if (contract is null) return NotFound();
        return Ok(contract);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CustomerRequestContract contract)
    {
        var created = service.Create(contract);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
    
}