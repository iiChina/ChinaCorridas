using Facul.Domain;
using Facul.Models;
using Facul.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Facul.Controllers;

[ApiController]
[Route("driver/")]
public class DriverController : ControllerBase
{
    private readonly DriverRepository _driverRepository;
    public DriverController(DriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    [HttpPost("/")]
    public async Task<IActionResult> CreateDriver(DriverInput input)
    {
        var driver = Driver.Create(input.Name, input.Email, input.Document, input.CarPlate);
        await _driverRepository.Save(driver);
        return Ok(driver.Id);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetDriver(string driverId)
    {
        var driver = await _driverRepository.Get(driverId);
        return Ok(driver);
    }
}
