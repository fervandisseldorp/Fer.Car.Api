using Fer.Car.Domain.Cars.Models;
using Fer.Car.Domain.Cars.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fer.Car.Api.Controllers.Car;

[ApiController]
[Route("cars")]
public class CarController(ICarService carService) : ControllerBase
{
    private readonly ICarService _carService = carService;

    [HttpGet]
    public IEnumerable<CarModel> GetCars()
    {
        return _carService.GetCars();
    }

    [HttpGet]
    [Route("{carId:guid}")]
    public CarModel GetCar(Guid carId)
    {
        return _carService.GetCar(carId);
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import(IFormFile file, CancellationToken cancellationToken)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Excel file is required.");

        using var stream = file.OpenReadStream();
        await _carService.ImportFromCsvAsync(stream, cancellationToken);
        return Accepted();
    }
}
