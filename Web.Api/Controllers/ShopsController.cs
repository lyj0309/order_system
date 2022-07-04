using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace Web.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopsController : ControllerBase
{
    readonly IShopService shopService;

    public ShopsController(IShopService shopService)
    {
        //依赖注入 
        this.shopService = shopService;
    }

    [HttpPost("register")]
    public IActionResult Register(ShopModel model)
    {

        try
        {
            this.shopService.Create(model);
            return new JsonResult(new ResponseModel<bool>());
        }
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false,e.Message));
        }
    }
}