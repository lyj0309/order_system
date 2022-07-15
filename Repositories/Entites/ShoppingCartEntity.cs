namespace Repositories;
[Table("ShoppingCart")]
public class ShoppingCartEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
}
