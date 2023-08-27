using Facul.Domain;
using Facul.Models;
using Microsoft.AspNetCore.Mvc;

namespace Facul.Controllers;

[ApiController]
[Route("[controller]")]
public class RideController : Controller
{
    [HttpPost]
    [Route("calculate_ride")]
    public IActionResult Calc(CalculateRideInput input)
    {
        try
        {
            var ride = new Ride();
            foreach (var position in input.Positions)
            {
                ride.AddPosition(position.Lat, position.Lon, position.Date);
            }
            var price = ride.Calculate();
            return Ok(price);
        }
        catch(Exception ex)
        {
            return UnprocessableEntity(ex.Message);
        }
    }
}