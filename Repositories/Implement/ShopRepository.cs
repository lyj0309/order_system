﻿namespace Repositories
{
    public class ShopRepository : RepositoryBase<ShopEntity>, IShopRepository
    {
        private readonly SqlContext db;

        public ShopRepository(SqlContext context)
        {
            this.db = context;
        }




        /*        public void Add(ShopEntity entity)
       {
           db.Add(entity);
           db.SaveChanges();
       }*/
    }
}
