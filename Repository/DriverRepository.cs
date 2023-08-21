using Facul.Database;
using Facul.Domain;

namespace Facul.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly IDatabaseConnection _connection;
        public DriverRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<Driver> Get(string driverId)
        {
            var driverData = await _connection.Query("", new Dictionary<string, object> { { "", driverId } });
            driverData.Read();
            return new Driver(driverData.GetString(0), driverData.GetString(1), driverData.GetString(2), driverData.GetString(3), driverData.GetString(4));
        }

        public async Task Save(Driver driver)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "", driver.Id },
                { "", driver.Name },
                { "", driver.Email.Value },
                { "", driver.Document.Value },
                { "", driver.CarPlate.Value }
            };
            await _connection.Query("", parameters);
        }
    }
}
