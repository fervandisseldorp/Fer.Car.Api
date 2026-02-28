using Fer.Car.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fer.Car.Repository.Repositories.Implementations;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext dbContext;

    public CarRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddRangeAsync(IEnumerable<Entities.Car> cars, CancellationToken cancellationToken = default)
    {
        await dbContext.Cars.AddRangeAsync(cars, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Entities.Car> GetCars()
    {
        return dbContext.Cars.AsNoTracking();
    }

    public async Task<bool> ExistsByLicensePlateAsync(string licensePlateNumber, CancellationToken cancellationToken = default)
    {
        return await dbContext.Cars
            .AsNoTracking()
            .AnyAsync(c => c.LicensePlateNumber == licensePlateNumber, cancellationToken);
    }
}