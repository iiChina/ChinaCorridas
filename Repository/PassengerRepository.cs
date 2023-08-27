using Facul.Database;
using Facul.Domain;

namespace Facul.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly IDatabaseConnection _connection;

        public PassengerRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<Passenger> GetAsync(string passengerId)
        {
            var passengerData = await _connection.QueryAsync("SELECT id, name, cpf, email FROM passengers WHERE id = @Id", new Dictionary<string, object>()
            {
                { "@Id", passengerId }
            });
            passengerData.Read();
            return new Passenger(passengerData.GetString(0), passengerData.GetString(1), passengerData.GetString(2), passengerData.GetString(3));
        }

        public async Task SaveAsync(Passenger passenger)
        {
            await _connection.ExecuteAsync($@"
                INSERT INTO passengers (id, name, cpf, email) 
                VALUES (@Id, @Name, @CPF, @Email)
            ", new Dictionary<string, object>()
            {
                { "@Id", passenger.Id},
                { "@Name", passenger.Name },
                { "@CPF", passenger.Document.Value },
                { @"Email", passenger.Email.Value }
            });
        }
    }
}
