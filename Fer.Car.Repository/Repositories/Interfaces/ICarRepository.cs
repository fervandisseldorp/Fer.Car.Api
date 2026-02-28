namespace Fer.Car.Repository.Repositories.Interfaces;

public interface ICarRepository
{
    Task AddRangeAsync(IEnumerable<Entities.Car> cars, CancellationToken cancellationToken = default);

    IQueryable<Entities.Car> GetCars();

    Task<bool> ExistsByLicensePlateAsync(string licensePlateNumber, CancellationToken cancellationToken = default);
}