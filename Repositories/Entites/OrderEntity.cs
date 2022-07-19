namespace Repositories;

[Table("Orders")]
public class OrderEntity
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ShopId { get; set; }
    public Guid ProductId { get; set; }
    public OrderSataus Status { get; set; }
    public DateTime CreateTime { get; set; }

}

public enum OrderSataus
{
    UnDone,
    Done,
}