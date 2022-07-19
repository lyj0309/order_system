namespace Repositories
{
    public interface IOrderRepository: IRepository<OrderEntity>
    {
        void Done(Guid id);
        void Receive(Guid id, Guid shopId);
    }
}
