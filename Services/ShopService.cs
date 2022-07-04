using Common;
using Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class ShopService : IShopService
{
    public void Create(ShopModel model)
    {
        var entity = model.MapTo<ShopEntity>();
        //var entity = new ShopEntity()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = model.Name  ,
        //    Address = model.Address ,
        //    Password = model.Password.ToSHA512() ,
        //};
        throw new NotImplementedException() ;
    }
}
