using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts.Orders;
using WebShoppie.Domain.Services.Interfaces;

namespace WebShoppie.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(IOrderService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<OrderResponseContract>> CreateOrder([FromBody] OrderRequestContract orderToCreate)
    {
        var created = await service.CreateOrderAsync(orderToCreate);
        return CreatedAtAction(nameof(GetOrder), new {Id = created.OrderId }, created);
        
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponseContract>> GetOrder([FromRoute] int id)
    {
        var result = await service.GetOrderByIdAsync(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}