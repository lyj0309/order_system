using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderModel
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
