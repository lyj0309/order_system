namespace Services
{
    public interface IProductService
    {
        public void Create(ProductModel model);
        void PullOff(Guid id);
        List<ProductModel> GetByShopId(Guid shopId);
    }
}
