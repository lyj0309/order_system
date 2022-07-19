namespace Repositories
{
    public class OrderRepository : RepositoryBase<OrderEntity>, IOrderRepository
    {
        public void Done(Guid id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Id", id);
            var sql = $"UPDATE {tableName} SET Status={(int)OrderSataus.Done} WHERE Id=@Id";
            this.databaseHelper.ExecuteNonQuery(sql, parameters);
        }

        public void Receive(Guid id, Guid shopId)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Id", id);
            parameters.Add("ShopId", shopId);
            var sql = $"UPDATE {tableName} SET ShopId=@ShopId WHERE Id=@Id";
            this.databaseHelper.ExecuteNonQuery(sql, parameters);
        }
    }
}
