namespace Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public List<ProductEntity> GetByShopId(Guid id)
        {
            var result = new List<ProductEntity>();
            var parameters = new Dictionary<string, object>();
            parameters.Add("ShopId", id);
            var sql = $"SELECT * FROM {this.tableName} WHERE ShopId=@ShopId AND IsDeleted={Convert.ToInt16(false)}";
            this.databaseHelper.ExecuteReader(reader => result.Add(ConstructObject(reader)), sql, parameters);
            return result;
        }

        public void PullOff(Guid id)
        {

            var parameters = new Dictionary<string, object>();
            parameters.Add("Id", id);
            var sql = $"UPDATE {tableName} SET IsDeleted={Convert.ToInt16(true)} WHERE Id=@Id";
            this.databaseHelper.ExecuteNonQuery(sql, parameters);
        }
    }

}
