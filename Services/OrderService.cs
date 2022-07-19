using Common;

namespace Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository OrderRepository;
    public OrderService(IOrderRepository OrderRepository)
    {
        this.OrderRepository = OrderRepository;
    }
    public void Create(OrderModel model)
    {
        var entity = new OrderEntity()
        {
            Id = Guid.NewGuid(),
            CustomerId = model.CustomerId,
            ShopId = Guid.Empty,
            ProductId = model.ProductId,
            Status = OrderSataus.UnDone,
            CreateTime = DateTime.Now,

        };
        this.OrderRepository.Add(entity);
    }

    public void Done(Guid id)
    {
        this.OrderRepository.Done(id);
    }

    public void Receive(Guid id, Guid shopId)
    {
        this.OrderRepository.Receive(id,shopId);
    }
}
