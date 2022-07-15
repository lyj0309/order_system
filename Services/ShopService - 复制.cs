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

    public List<ShopModel> GetAll()
    {
        var list = this.shopRepository.GetAll();
        list.ForEach(s=>s.Password = string.Empty);
        return list.MapToList<ShopModel>();
    }   

    public ShopModel? Login(LoginRequest request)
    {
        var entity = this.shopRepository.GetByNameAndPass(request.Name, request.Password.ToSHA512());
        if (entity != null)
        {
            return new ShopModel() { Name = entity.Name};
        }
        return null;
    }

    public ShopModel GetById(Guid id)
    {
        var shop = this.shopRepository.GetById(id);
        if (shop != null)
        {
            shop.Password = string.Empty;
        }
        return shop.MapTo<ShopModel>();
    }
}
