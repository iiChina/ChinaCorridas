using Facul.Domain;

namespace Facul.Repository;

public interface IDriverRepository
{
    public Task Save(Driver driver);
    public Task<Driver> Get(string driverId);
}
