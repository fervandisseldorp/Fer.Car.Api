using Fer.Car.Repository.Repositories.Implementations;
using Fer.Car.Repository.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fer.Car.Repository;

public static class Registrations
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICarRepository, CarRepository>();
        return services;
    }
}
