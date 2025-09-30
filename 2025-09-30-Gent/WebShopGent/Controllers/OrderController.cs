using Microsoft.AspNetCore.Mvc;
using WebShopGent.Contracts;
using WebShopGent.Services;

namespace WebShopGent.Controllers;

[ApiController]
[Route("orders")]
public class OrderController(OrderService service) : ControllerBase
{
    //TODO Ongetest!! We doen dat volgende keer
    
    [HttpPost]
    public IActionResult Create([FromBody] OrderRequestContract contract)
    {
        // hier iets cleaner doen met status en return body
        service.CreateOrder(contract);
        return Ok();
    }
}