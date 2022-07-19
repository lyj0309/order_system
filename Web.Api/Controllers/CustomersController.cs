using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class CustomersController : ControllerBase
{
    readonly ICustomerService customerService;

    public CustomersController(ICustomerService customerService)
    {
        //依赖注入 
        this.customerService = customerService;
    }

    [HttpPost("register")]
    public IActionResult Register(CustomerModel model)
    {
        try
        {
            this.customerService.Create(model);
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
            var customers = this.customerService.GetAll();
            return new JsonResult(new ResponseModel<List<CustomerModel>>(customers));
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
            var model = this.customerService.Login(request);
            if (model == null)
            {
                return new JsonResult(new ResponseModel<bool>(false, "the user name or pass is not correct"));
            }
            return new JsonResult(new ResponseModel<CustomerModel>(model));
        } 
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }
}