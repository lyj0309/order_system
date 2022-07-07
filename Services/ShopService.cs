using Common;

namespace Services;

public class ShopService : IShopService
{
    private readonly IShopRepository shopRepository;
    public ShopService(IShopRepository shopRepository)
    {
        this.shopRepository = shopRepository;
    }
    public void Create(ShopModel model)
    {
        var entity = model.MapTo<ShopEntity>();
        this.shopRepository.Add(entity);
        //var entity = new ShopEntity()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = model.Name  ,
        //    Address = model.Address ,
        //    Password = model.Password.ToSHA512() ,
        //};
    }
}
