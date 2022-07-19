namespace Repositories
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        List<ProductEntity> GetByShopId(Guid id);

        void PullOff(Guid id);

    }
}
