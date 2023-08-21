using Facul.Domain;
using Facul.Models;
using Facul.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Facul.Controllers;

[ApiController]
[Route("/passenger")]
public class PassengerController : ControllerBase
{
    private readonly IPassengerRepository _passengerRepository;

    public PassengerController(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    [HttpPost("/")]
    public async Task<IActionResult> CreatePassenger(PassengerInput input)
    {
        var passenger = Passenger.Create(input.Name, input.Email, input.Document);
        await _passengerRepository.Save(passenger);
        return Ok(passenger.Id);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetPassenger(string passengerId)
    {
        var passenger = _passengerRepository.Get(passengerId);
        return Ok(passenger);
    }
}
