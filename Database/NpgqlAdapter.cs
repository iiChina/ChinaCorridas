using Npgsql;
using System.Data;

namespace Facul.Database
{
    public class NpgqlAdapter : IDatabaseConnection
    {
        private readonly NpgsqlConnection _connection;

        public NpgqlAdapter()
        {
            _connection = new NpgsqlConnection("");
        }

        public async Task Close()
        {
            await _connection.CloseAsync();
        }

        public IDataReader Query(string statement, IDataParameter parameters)
        {
            return null;
        }
    }
}
