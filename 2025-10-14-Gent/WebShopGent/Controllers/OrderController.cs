using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts;
using WebShoppie.Domain.Services;

namespace WebShoppie.Api.Controllers;

[ApiController]
[Route("orders")]
public class OrderController(IOrderService service) : ControllerBase
{
    //TODO Klasse laten compileren - build action staat momenteel op 'None'
    //TODO Alle operaties testen.
    
    [HttpPost]
    public IActionResult Create([FromBody] OrderRequestContract contract)
    {
        var created = service.CreateOrder(contract);
        return CreatedAtAction(nameof(Get), new { id = created.OrderId}, created);
    }

    [HttpGet("{id}")]
    public ActionResult<OrderResponseContract> Get([FromRoute] Guid id)
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