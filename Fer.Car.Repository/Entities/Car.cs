namespace Fer.Car.Repository.Entities;

public class Car
{
    public Guid Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string LicensePlateNumber { get; set; } = string.Empty;
    public int NumberOfSeats { get; set; }
}
