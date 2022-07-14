using System.Data;

namespace Repositories
{
    public interface IDatabaseHelper
    {
        void ExecuteNonQuery(string sql, Dictionary<string, object> parameters);
        public void ExecuteReader(Action<IDataReader> reader, string sql, Dictionary<string, object> parameters);
    }
}
