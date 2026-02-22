namespace Fer.Car.Repository.Repositories.Interfaces;

public interface ICarRepository
{
    IQueryable<Entities.Car> GetCars();
}
