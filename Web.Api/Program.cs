using Common;
using Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//注入服务
addServices(builder.Services);
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
//注入自己写的automapper拓展
app.Services.UseAutoMapper();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void addServices(IServiceCollection services)
{
    //使用单例模式
    services.AddSingleton<IShopService,ShopService>();

    services.AddAutoMapper(typeof(AutoMapperProfile));
    services.AddAutoMapper(Assembly.GetEntryAssembly());
}