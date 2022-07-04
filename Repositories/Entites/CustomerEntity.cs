using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class CustomerEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int Level { get; set; }
}