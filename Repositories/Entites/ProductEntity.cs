namespace Repositories;
public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Guid ShopId { get; set; }
    public bool IsDeleted { get; set; }

}