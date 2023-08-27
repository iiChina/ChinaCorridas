using System.Data.SqlClient;
using System.Data;

namespace Facul.Database
{
    public class SqlServerAdapter : IDatabaseConnection
    {
        private readonly SqlConnection _connection;

        public SqlServerAdapter()
        {
            _connection = new SqlConnection("Server=DESKTOP-OMU7ASO\\SQLEXPRESS;TrustServerCertificate=True;User Id=sa;Password=sa;Database=corridas");
            _connection.Open();
        }

        public async Task CloseAsync()
        {
            await _connection.CloseAsync();
        }

        public async Task ExecuteAsync(string statement, Dictionary<string, object> parameters)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = statement;
                command.CommandType = CommandType.Text;
                foreach(var parameter in parameters)
                {
                    SqlParameter param = new SqlParameter(parameter.Key, parameter.Value);
                    command.Parameters.Add(param);
                }

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task OpenAsync()
        {
            await _connection.OpenAsync();
        }

        public async Task<IDataReader> QueryAsync(string statement, Dictionary<string, object> parameters)
        {
            using var command = _connection.CreateCommand();    
            command.CommandText = statement;
            command.CommandType = CommandType.Text;
            foreach (var parameter in parameters)
                command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value)); 
            return await command.ExecuteReaderAsync();
        }
    }
}
