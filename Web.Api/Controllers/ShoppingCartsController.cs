using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class ShoppingCartController : ControllerBase
{
    readonly IShoppingCartService shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        //依赖注入 
        this.shoppingCartService = shoppingCartService;
    }

    [HttpPost]
    public IActionResult New(ShoppingCartModel model)
    {
        try
        {
            this.shoppingCartService.Create(model);
            return new JsonResult(new ResponseModel<bool>());
        }
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            this.shoppingCartService.Delete(id);
            return new JsonResult(new ResponseModel<bool>());
        }
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }

}