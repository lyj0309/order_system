using Common;

namespace Services;


public class ProductService : IProductService
{
    private readonly IProductRepository ProductRepository;
    public ProductService(IProductRepository ProductRepository)
    {
        this.ProductRepository = ProductRepository;
    }
    public void Create(ProductModel model)
    {
        var entity = new ProductEntity()
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Price = model.Price,
            ShopId = model.ShopId,
            IsDeleted = false,
        };
        this.ProductRepository.Add(entity);
    }

    public List<ProductModel> GetByShopId(Guid shopId)
    {
        var Products = this.ProductRepository.GetByShopId(shopId);
        return Products.MapToList<ProductModel>();
    }

    
    public void PullOff(Guid id)
    {
        this.ProductRepository.PullOff(id);
    }
}
