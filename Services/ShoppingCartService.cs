using Common;

namespace Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository shoppingCartRepository;
    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
    {
        this.shoppingCartRepository = shoppingCartRepository;
    }

    public void Create(ShoppingCartModel model)
    {
        this.shoppingCartRepository.Add(new ShoppingCartEntity()
        {
            Id = Guid.NewGuid(),
            ProductId = model.ProductId,
            CustomerId = model.CustomerId,
        });
    }

    public void Delete(Guid id)
    {
        this.shoppingCartRepository.Delete(id);
    }
}
