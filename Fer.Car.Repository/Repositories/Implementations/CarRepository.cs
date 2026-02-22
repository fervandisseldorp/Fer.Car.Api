using Fer.Car.Repository.Repositories.Interfaces;

namespace Fer.Car.Repository.Repositories.Implementations;

public class CarRepository : ICarRepository
{
    public IQueryable<Entities.Car> GetCars()
    {
        var list = new List<Entities.Car>
        {
            new Entities.Car
            {
                Id = Guid.NewGuid(),
                Brand = "Toyota",
                LicensePlateNumber = "SZ388G",
                NumberOfSeats = 5
            },
            new Entities.Car
            {
                Id = Guid.NewGuid(),
                Brand = "Dacia",
                LicensePlateNumber = "SZ390T",
                NumberOfSeats = 4
            }
        };

        return list.AsQueryable();
    }
}
