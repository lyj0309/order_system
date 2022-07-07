using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly SqlContext db;

        public ShopRepository(SqlContext context)
        {
            this.db = context;
        }
        public void Add(ShopEntity entity)
        {
            db.Add(entity);
            db.SaveChanges();
        }
    }
}
