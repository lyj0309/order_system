namespace Services
{
    public interface IShoppingCartService
    {
        public void Create(ShoppingCartModel model);
        public void Delete(Guid id);

    }
}
