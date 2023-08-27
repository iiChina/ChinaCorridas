using Facul.Domain;
using System.Data;

namespace Facul.Repository
{
    public interface IPassengerRepository
    {
        public Task SaveAsync(Passenger passenger);
        public Task<Passenger> GetAsync(string passengerId);
    }
}
