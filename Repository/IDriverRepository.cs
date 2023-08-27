using Facul.Domain;

namespace Facul.Repository;

public interface IDriverRepository
{
    public Task SaveAsync(Driver driver);
    public Task<Driver> GetAsync(string driverId);
}
