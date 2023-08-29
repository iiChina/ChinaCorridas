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

        public async Task<List<Driver>> GetAllAsync()
        {
            using var driversData = await _connection.QueryAsync("SELECT id, name, cpf, email, carPlate FROM drivers");

            List<Driver> drivers= new List<Driver>();
            while (driversData.Read())
            {
                drivers.Add(new Driver(driversData.GetString(0), driversData.GetString(1),
                    driversData.GetString(2), driversData.GetString(3), driversData.GetString(4)));
            }

            return drivers;
        }

        public async Task<Driver> GetAsync(string driverId)
        {
            var driverData = await _connection.QueryAsync("SELECT id, name, email, cpf, car_plate FROM drivers WHERE id = @Id", 
                new Dictionary<string, object> { { "@Id", driverId } });

            driverData.Read();
            return new Driver(driverData.GetString(0), driverData.GetString(1), driverData.GetString(2), driverData.GetString(3), driverData.GetString(4));
        }
        
        public async Task SaveAsync(Driver driver)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@Id", driver.Id },
                { "@Name", driver.Name },
                { "@Email", driver.Email.Value },
                { "@CPF", driver.Document.Value },
                { "@CarPlate", driver.CarPlate.Value }
            };
            await _connection.ExecuteAsync($@"
                INSERT INTO drivers (id, name, email, cpf, car_plate) 
                VALUES (@Id, @Name, @Email, @CPF, @CarPlate)
            ", parameters);
        }
    }
}
