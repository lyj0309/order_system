using System.Data;
using System.Reflection;

namespace Repositories
{
    public class RepositoryBase<T> : IRepository<T>
    {
        protected string tableName = typeof(T).GetCustomAttribute<TableAttribute>()?.TableName;

        protected IDatabaseHelper databaseHelper = new DatabaseHelper(ConfigurationHelper.ConnectionString);

        private readonly SqlContext db;


        /*        public RepositoryBase(SqlContext context)
                {
                    this.db = context;

                }*/
        public void Add(T entity)
        {
            Dictionary<string, object> parameters = GetAllProperties(entity);
            var sql = $"INSERT INTO {tableName} ([{String.Join("],[", parameters.Keys)}]) VALUES (@{String.Join(",@", parameters.Keys)} )";
            this.databaseHelper.ExecuteNonQuery(sql, parameters);
        }
        public void Delete(Guid id)
        {
            var sql = $"DELETE FROM {this.tableName} WHERE Id = @Id";
            var parameter = new Dictionary<string, object>
            {
                { "@Id", id },
            };
            this.databaseHelper.ExecuteNonQuery(sql, parameter);
        }

        public List<T> GetAll()
        {
            var result = new List<T>();
            var sql = $"SELECT * FROM {this.tableName}";
            this.databaseHelper.ExecuteReader(reader => result.Add(ConstructObject(reader)), sql, null);
            return result;
        }

        public T GetById(Guid id)
        {
            var result = default(T);
            var sql = $"SELECT * FROM {this.tableName} WHERE Id = @Id";
            var parameter = new Dictionary<string, object>
            {
                { "@Id", id },
            };
            this.databaseHelper.ExecuteReader(reader => result = ConstructObject(reader), sql, parameter);
            return result;
        }

        public T GetByNameAndPass(string name, string pass)
        {
            var result = default(T);
            var sql = $"SELECT Name FROM {this.tableName} WHERE Name = @Name AND Password = @Password";
            var parameter = new Dictionary<string, object>
            {
                { "@Name", name },
                { "@Password", pass }
            };
            this.databaseHelper.ExecuteReader(reader => result = ConstructObject(reader), sql, parameter);
            return result;
        }

        protected T ConstructObject(IDataReader reader)
        {
            return Constructobject<T>(reader);
        }

        protected TDomain Constructobject<TDomain>(IDataReader record)
        {
            var dataType = typeof(TDomain);
            var instance = Activator.CreateInstance<TDomain>();
            var properties = dataType.GetProperties();
            foreach (var item in GetAllNames(record))
            {
                var key = item.Key.ToLower();
                if (!properties.Any(p => p.Name.Equals(key, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }
                var property = properties.First(p => p.Name.Equals(key, StringComparison.OrdinalIgnoreCase));
                if (property != null)
                {
                    var colValue = default(object);
                    if (!record.IsDBNull(item.Value))
                    {
                        colValue = record.GetValue(item.Value);
                    }
                    var propertyType = property.PropertyType;
                    if (colValue != null && !(colValue.GetType() == propertyType) &&
                    !typeof(ValueType).IsAssignableFrom(propertyType))
                    {
                        colValue = Convert.ChangeType(colValue, propertyType);
                    }
                    else if (colValue == null && typeof(ValueType).IsAssignableFrom(propertyType))
                    {
                        colValue = Activator.CreateInstance(propertyType);
                    }
                    property.SetValue(instance, colValue, null);
                }
            }
            return instance;
        }

        private Dictionary<String, Int32> GetAllNames(IDataRecord record)
        {
            var result = new Dictionary<String, Int32>();
            for (var i = 0; i < record.FieldCount; i++)
                result.Add(record.GetName(i), i);
            return result;
        }

        private Dictionary<string, object> GetAllProperties(T? entry)
        {
            var allProperties = typeof(T).GetProperties();
            var parameters = new Dictionary<string, object>();
            foreach (var property in allProperties)
            {
                parameters.Add(property.Name, property.GetValue(entry));
            }
            return parameters;
        }
    }
}
