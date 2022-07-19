using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid ShopId { get; set; }
    }
}
