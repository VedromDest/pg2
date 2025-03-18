using Microsoft.AspNetCore.Mvc;
using Storefront.Api.Contracts;
using Storefront.Services;

namespace Storefront.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(IOrderService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<OrderResponseContract>> GetAll()
    {
        return Ok(service.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<OrderResponseContract> Get([FromRoute] int id)
    {
        var order = service.Get(id);
        if (order is null) return NotFound();
        return Ok();
    }
    
    [HttpPost]
    public ActionResult<OrderResponseContract> Create(
        [FromBody] OrderRequestContract orderRequestContract)
    {
        var created = service.Create(orderRequestContract);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
}