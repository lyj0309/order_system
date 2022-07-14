namespace Repositories
{
    public class CustomerRepository : RepositoryBase<CustomerEntity>, ICustomerRepository
    {
        private readonly SqlContext db;

        public CustomerRepository(SqlContext context)
        {
            this.db = context;
        }

        /*        public void Add(CustomerEntity entity)
       {
           db.Add(entity);
           db.SaveChanges();
       }*/
    }
}
