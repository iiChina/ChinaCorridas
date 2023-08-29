using Facul.Domain;
using Facul.Models;
using Facul.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Facul.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("CorsPolicy")]
public class PassengerController : Controller
{
    private readonly IPassengerRepository _passengerRepository;

    public PassengerController(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePassenger(PassengerInput input)
    {
        var passenger = Passenger.Create(input.Name, input.Email, input.Document);
        await _passengerRepository.SaveAsync(passenger);
        return Ok(passenger.Id);
    }

    [HttpGet("{passengerId}")]
    public async Task<IActionResult> GetPassenger(string passengerId)
    {
        var passenger = await _passengerRepository.GetAsync(passengerId);
        return Ok(passenger);
    }

    [HttpGet]
    public async Task<IActionResult> GetPassengers()
    {
        var passengers = await _passengerRepository.GetAllAsync();
        return Ok(passengers);
    }
}
