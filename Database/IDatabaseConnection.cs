using System.Data;

namespace Facul.Database
{
    public interface IDatabaseConnection
    {
        public Task<IDataReader> Query(string statement, Dictionary<string, object> parameters);
        public Task Close();
    }
}
