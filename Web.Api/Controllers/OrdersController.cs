using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class OrdersController : ControllerBase
{
    readonly IOrderService orderService;

    public OrdersController(IOrderService orderService)
    {
        //依赖注入 
        this.orderService = orderService;
    }

    [HttpPost()]
    public IActionResult New(OrderModel model)
    {
        try
        {
            this.orderService.Create(model);
            return new JsonResult(new ResponseModel<bool>());
        }
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }
    [HttpPatch("{id}/done")]
    public IActionResult Done(Guid id)
    {
        try
        {
            this.orderService.Done(id);
            return new JsonResult(new ResponseModel<bool>());
        }
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }

    [HttpPatch("{id}/receive")]
    public IActionResult Receive(Guid id,Guid ShopId)
    {
        try
        {
            this.orderService.Receive(id,ShopId);
            return new JsonResult(new ResponseModel<bool>());
        } 
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }
}