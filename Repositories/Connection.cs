global using Common;
using Microsoft.EntityFrameworkCore;

namespace Repositories;
public class SqlContext : DbContext
{
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }
    public DbSet<ShopEntity> Shops { get; set; }

    public string DbPath { get; }

    private readonly string connectionString;


    /*    public SqlContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }*/
    public SqlContext(DbContextOptions<SqlContext> options)
        : base(options)
    {
    }
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    /*    protected override void OnConfiguring(DbContextOptionsBuilder options)
            //=> options.UseSqlite($"Data Source={DbPath}");
            //=> options.UseSqlite(ConfigurationHelper.ConnectionString);
            => options.UseSqlServer("server=10.2.40.78;uid=SA;pwd=Dlpu123456;database=testdb");*/
}