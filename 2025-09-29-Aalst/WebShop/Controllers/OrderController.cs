using Microsoft.AspNetCore.Mvc;
using WebShop.Contracts;
using WebShop.Repositories;
using WebShop.Services;

namespace WebShop.Controllers;

[ApiController]
[Route("orders")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public ActionResult<OrderResponseContract> Create([FromBody]OrderRequestContract orderToCreate)
    {
        var created = orderService.CreateSingleOrder(orderToCreate);
        
        //TODO return createdAtAction
        return Ok(created);
    }
}