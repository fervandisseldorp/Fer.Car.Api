namespace Fer.Car.Domain.Cars.ExternalModels;

public class CarCsvRow
{
    public string Brand { get; set; } = default!;
    public string LicensePlateNumber { get; set; } = default!;
    public int? NumberOfSeats { get; set; }
}