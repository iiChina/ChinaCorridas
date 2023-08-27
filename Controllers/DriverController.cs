using Facul.Domain;
using Facul.Models;
using Facul.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Facul.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : Controller
{
    private readonly IDriverRepository _driverRepository;
    public DriverController(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver(DriverInput input)
    {
        var driver = Driver.Create(input.Name, input.Email, input.Document, input.CarPlate);
        await _driverRepository.SaveAsync(driver);
        return Ok(driver.Id);
    }

    [HttpGet]
    [Route("{driverId}")]
    public async Task<IActionResult> GetDriver(string driverId)
    {
        var driver = await _driverRepository.GetAsync(driverId);
        return Ok(driver);
    }
}
