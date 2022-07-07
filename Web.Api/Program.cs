global using Common;
global using Services;
global using Repositories;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

//初始化
ConfigurationHelper.Init();
var builder = WebApplication.CreateBuilder(args);

//注入服务
addServices(builder.Services);

//数据库初始化

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//自动创建数据库
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SqlContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}
//注入自己写的automapper拓展
app.Services.UseAutoMapper();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void addServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddDbContext<SqlContext>(
        options=>options.UseSqlServer("server=10.2.40.78;uid=SA;pwd=Dlpu123456;database=testdb"));

    //使用单例模式
    //services.AddSingleton<IShopService, ShopService>();

    //scoped模式，一次请求的生命周期
    services.AddScoped<IShopService, ShopService>();
    services.AddScoped<IShopRepository, ShopRepository>();

    //数据库context,应该使用的工厂模式

    services.AddAutoMapper(typeof(AutoMapperProfile));
    services.AddAutoMapper(Assembly.GetEntryAssembly());
}