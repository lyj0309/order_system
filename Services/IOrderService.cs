namespace Services
{
    public interface IOrderService
    {
        void Create(OrderModel model);
        void Receive(Guid id,Guid ShopId);
        void Done(Guid id);
    }
}
