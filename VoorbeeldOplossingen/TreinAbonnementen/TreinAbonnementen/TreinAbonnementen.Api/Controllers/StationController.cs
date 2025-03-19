using Microsoft.AspNetCore.Mvc;
using TreinAbonnementen.Api.Contracts;
using TreinAbonnementen.Service;

namespace TreinAbonnementen.Controllers;

[ApiController]
[Route("api/stations")]
public class StationController(IStationService service) : ControllerBase
{
    
    [HttpGet()]
    public IActionResult GetAll()
    {
        return Ok(service.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var contract = service.GetById(id);
        if (contract is null) return NotFound();
        return Ok(contract);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] StationRequestContract contract)
    {
        var created = service.Create(contract);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] StationRequestContract contract)
    {
        try
        {
            service.UpdateById(id, contract);
        }
        catch (EntityNotFoundException e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }  
    
}