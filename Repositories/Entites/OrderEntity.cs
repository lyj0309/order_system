namespace Repositories;


public class OrderEntity
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ShopId { get; set; }
    public Guid ProductId { get; set; }
    public int Status { get; set; }
    public DateTime CreateTime { get; set; }

}


