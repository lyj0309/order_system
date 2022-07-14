using System.Data;
using System.Data.Common;

namespace Repositories
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");
        private string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            using var connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = this.connectionString;
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.CommandTimeout = 300;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = param.Key;
                    dbParameter.Value = param.Value ?? DBNull.Value;
                    command.Parameters.Add(dbParameter);
                }
            }
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ExecuteReader(Action<IDataReader> reader, string sql, Dictionary<string, object> parameters)
        {
            using var connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = this.connectionString;
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.CommandTimeout = 300;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = param.Key;
                    dbParameter.Value = param.Value ?? DBNull.Value;
                    command.Parameters.Add(dbParameter);
                }
            }
            using var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                reader(dataReader);
            }
            connection.Close();
        }
    }
}
