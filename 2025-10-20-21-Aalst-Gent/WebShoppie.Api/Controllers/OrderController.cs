using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Services.Exceptions;
using WebShoppie.Domain.Services.Interfaces;

namespace WebShoppie.Api.Controllers;

[ApiController]
[Route("orders")]
public class OrderController(IOrderService service) : ControllerBase
{    
    [HttpPost]
    public IActionResult Create([FromBody] OrderRequestContract contract)
    {
        try
        {
            var created = service.CreateOrder(contract);
            return CreatedAtAction(nameof(Get), new { id = created.OrderId }, created);
        }
        catch(InvalidOrderException ioe)
        {
            return BadRequest(
                new ProblemDetails { 
                    Status = (int)HttpStatusCode.BadRequest, 
                    Title = ioe.Message 
                });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<OrderResponseContract> Get([FromRoute] int id)
    {
        var order = service.GetOrder(id);

        if (order is null)
            return NotFound();

        return Ok(order);
    }

    [HttpGet]
    public ActionResult<List<OrderOverviewResponseContract>> GetAll()
    {
        return Ok(service.GetAllOrders());
    }
}