using Facul.Domain;
using System.Data;

namespace Facul.Repository
{
    public interface IPassengerRepository
    {
        public Task Save(Passenger passenger);
        public Task<Passenger> Get(string passengerId);
    }
}
