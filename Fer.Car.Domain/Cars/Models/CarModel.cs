namespace Fer.Car.Domain.Cars.Models;

public class CarModel
{
    public Guid Id { get; set; }
    public string LicensePlateNumber { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public int NumberOfSeats { get; set; }
}
