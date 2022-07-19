using Lib;
using Model;
using System;

Console.WriteLine("开始请求···");

try
{
    await testCustomer();
    await testOrder();
    await testProduct();
    await testShop();
    await testShoppingCart();
}
catch (Exception e)
{
    Console.WriteLine(e);
}
async Task testCustomer()
{
    //新建
    await Client.Request("Customers/register", "POST", new CustomerModel()
    {
        Name = "test",
        Password = "123456",
        Level = CustomerLevel.Gold,
    });
    //获取
    await Client.Request("Customers", "GET", null);
    //登录
    await Client.Request("Customers/login", "POST", new LoginRequest()
    {
        Name = "test",
        Password = "123456"
    });
}

async Task testOrder()
{
    //新建
    await Client.Request("Orders", "POST", new OrderModel()
    {
        CustomerId = Guid.NewGuid(),
        ProductId = Guid.NewGuid()
    });
    await Client.Request("Orders/75445e20-8563-4916-bbad-e27704e275ba/done", "PATCH", null);
    await Client.Request("Orders/75445e20-8563-4916-bbad-e27704e275ba/receive?ShopId="+Guid.NewGuid(), "PATCH", null);
}
async Task testProduct()
{
    var shopid = Guid.NewGuid();
    await Client.Request("Products", "POST", new ProductModel()
    {
        Name = "test",
        Price = 100,
        ShopId = shopid,
    });
    await Client.Request("Products?shopid=" + shopid, "GET", null);
    await Client.Request("Products/79b08c7b-fb96-4ad2-b014-cc3c1e3e29d9", "DELETE", null);
}

async Task testShop()
{
    //新建
    await Client.Request("Shops/register", "POST", new ShopModel()
    {
        Name = "test",
        Password = "123456",
        Address = "testtesttest"
    });
    //获取
    await Client.Request("Shops", "GET", null);
    await Client.Request("Shops/ae8a5b60-7160-41c2-c98c-08da5eed5317", "GET", null);
    //登录
    await Client.Request("Shops/login", "POST", new LoginRequest()
    {
        Name = "test",
        Password = "123456"
    });
}
async Task testShoppingCart()
{
    await Client.Request("ShoppingCart", "POST", new ShoppingCartModel()
    {
        ProductId = Guid.NewGuid(),
        CustomerId = Guid.NewGuid(),
    });
    
    await Client.Request("ShoppingCart/55faa5ad-46c1-4eff-b0c6-9bef5668aa42", "DELETE", null);
}
