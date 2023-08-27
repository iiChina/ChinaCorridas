using System.Data;

namespace Facul.Database
{
    public interface IDatabaseConnection
    {
        public Task<IDataReader> QueryAsync(string statement, Dictionary<string, object> parameters);
        public Task ExecuteAsync(string statement, Dictionary<string, object> parameters);
        public Task CloseAsync();
        public Task OpenAsync();
    }
}
