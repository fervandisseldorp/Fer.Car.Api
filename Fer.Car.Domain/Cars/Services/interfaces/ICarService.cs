using Fer.Car.Domain.Cars.Models;

namespace Fer.Car.Domain.Cars.Services.interfaces;

public interface ICarService
{
    IEnumerable<CarModel> GetCars();
    CarModel GetCar(Guid carId);
    Task ImportFromCsvAsync(Stream csvStream, CancellationToken cancellationToken = default);
}
