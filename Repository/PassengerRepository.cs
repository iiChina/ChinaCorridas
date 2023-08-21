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

        public async Task<Passenger> Get(string passengerId)
        {
            var passengerData = await _connection.Query("", new Dictionary<string, object>());
            return new Passenger(passengerData.GetString(0), passengerData.GetString(1), passengerData.GetString(2), passengerData.GetString(3);
        }

        public async Task Save(Passenger passenger)
        {
            await _connection.Query("", new Dictionary<string, object>());
        }
    }
}
