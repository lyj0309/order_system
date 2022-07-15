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
        var entity = model.MapTo<OrderEntity>();
        this.OrderRepository.Add(entity);
        //var entity = new OrderEntity()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = model.Name  ,
        //    Address = model.Address ,
        //    Password = model.Password.ToSHA512() ,
        //};
    }
}
