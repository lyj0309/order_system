using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductsController : ControllerBase
{
    readonly IProductService productService;

    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpPost]
    public IActionResult New(ProductModel model)
    {
        try
        {
            this.productService.Create(model);
            return new JsonResult(new ResponseModel<bool>());
        }
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }

    [HttpDelete("{id}")]
    public IActionResult PullOff(Guid id)
    {
        try
        {
            this.productService.PullOff(id);
            return new JsonResult(new ResponseModel<bool>());
        }
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }

    [HttpGet]
    public IActionResult GetByShopId(Guid shopid)
    {
        try
        {
            var model = this.productService.GetByShopId(shopid);
            if (model == null)
            {
                return new JsonResult(new ResponseModel<bool>(false, "nothing"));
            }
            return new JsonResult(new ResponseModel<List<ProductModel>>(model));
        }
        catch (Exception e)
        {
            return new JsonResult(new ResponseModel<bool>(false, e.Message));
        }
    }
}