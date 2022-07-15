using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Api.Controllers;

[ApiController]
[Route("shops")]
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
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }   
    [HttpGet()]
    public IActionResult GetAll()
    {
        try
        {
            var shops = this.shopService.GetAll();
            return new JsonResult(new ResponseModel<List<ShopModel>>(shops));
        } 
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }
    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        try
        {
            var guid = Guid.Parse(id);

            var shop = this.shopService.GetById(guid);
            return new JsonResult(new ResponseModel<ShopModel>(shop));
        } 
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }

    

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        try
        {
            var model = this.shopService.Login(request);
            if (model == null)
            {
                return new JsonResult(new ResponseModel<bool>(false, "the user name or pass is not correct"));
            }
            return new JsonResult(new ResponseModel<ShopModel>(model));
        } 
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }
}