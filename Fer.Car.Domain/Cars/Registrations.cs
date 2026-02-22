using Microsoft.Extensions.DependencyInjection;
using Fer.Car.Domain.Cars.Services.interfaces;
using Fer.Car.Domain.Cars.Services.Implementation;

namespace Fer.Car.Domain.Cars;

public static class Registrations
{
    public static IServiceCollection AddCarServices(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();
        return services;
    }
}
