using Fer.Car.Domain.Cars.Models;
using Fer.Car.Domain.Cars.Services.interfaces;
using Fer.Car.Repository.Repositories.Interfaces;

namespace Fer.Car.Domain.Cars.Services.Implementation;

public class CarService : ICarService
{
    private readonly ICarRepository carRepository;

    public CarService(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    public IEnumerable<CarModel> GetCars()
    {
        var cars = this.carRepository.GetCars();

        return cars.Select(car => new CarModel
        {
            Id = car.Id,
            LicensePlateNumber = car.LicensePlateNumber,
            Brand = car.Brand,
            NumberOfSeats = car.NumberOfSeats
        });
    }

    public CarModel GetCar(Guid carId)
    {
        return new CarModel
        {
            Id = new Guid(),
            LicensePlateNumber = "SZ388G",
            Brand = "Toyota",
            NumberOfSeats = 5
        };
    }
}
