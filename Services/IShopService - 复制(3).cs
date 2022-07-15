namespace Services
{
    public interface IShopService
    {
        public void Create(ShopModel model);

        List<ShopModel> GetAll();
        ShopModel Login(LoginRequest request);
        ShopModel GetById(Guid id);
    }
}
