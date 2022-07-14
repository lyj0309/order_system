namespace Repositories;
[Table("Shops")]
public class ShopEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
}
