namespace Services
{
    public interface IOrderService
    {
        void Create(OrderModel model);

        void SetDone(Guid id);
        void Recvive(Guid id);
    }
}
