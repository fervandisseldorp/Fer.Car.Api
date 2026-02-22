using Fer.Car.Domain.Cars.Models;
using Fer.Car.Domain.Cars.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fer.Car.Api.Controllers.Car;

[ApiController]
[Route("cars")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

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
}
