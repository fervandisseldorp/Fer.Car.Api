using Fer.Car.Domain.Cars.ExternalModels;
using Fer.Car.Domain.Cars.Models;
using Fer.Car.Domain.Cars.Services.interfaces;
using Fer.Car.Repository.Repositories.Interfaces;
using System.Globalization;
using System.Text;


namespace Fer.Car.Domain.Cars.Services.Implementation;

public class CarService : ICarService
{
    private readonly ICarRepository carRepository;
    private readonly CarImportOptions importOptions;
    private readonly int BatchSize = 50;

    public CarService(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    public IEnumerable<CarModel> GetCars()
    {
        var cars = this.carRepository.GetCars();

        return cars.Select(car => new CarModel
        {
            Id = car.Id,
            LicensePlateNumber = car.LicensePlateNumber,
            Brand = car.Brand,
            NumberOfSeats = car.NumberOfSeats
        });
    }

    public CarModel GetCar(Guid carId)
    {
        return new CarModel
        {
            Id = new Guid(),
            LicensePlateNumber = "SZ388G",
            Brand = "Toyota",
            NumberOfSeats = 5
        };
    }

    public async Task ImportFromCsvAsync(Stream csvStream, CancellationToken cancellationToken = default)
    {
        if (csvStream == null)
            throw new ArgumentNullException(nameof(csvStream));

        csvStream.Position = 0;

        using var reader = new StreamReader(csvStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, leaveOpen: true);

        var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true,
            TrimOptions = CsvHelper.Configuration.TrimOptions.Trim,
            IgnoreBlankLines = true,
            BadDataFound = null,       // ignore bad data
            MissingFieldFound = null,  // ignore missing fields
            HeaderValidated = null     // skip header validation errors
        };

        using var csv = new CsvHelper.CsvReader(reader, csvConfig);

        // Use your existing ClassMap for mapping CSV columns
        csv.Context.RegisterClassMap<CarCsvRowMap>();

        var carsBuffer = new List<Repository.Entities.Car>(BatchSize);

        await foreach (var row in csv.GetRecordsAsync<CarCsvRow>())
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Skip if any required field is missing
            if (string.IsNullOrWhiteSpace(row.Brand) ||
                string.IsNullOrWhiteSpace(row.LicensePlateNumber) ||
                !row.NumberOfSeats.HasValue || row.NumberOfSeats <= 0)
                continue;

            // Skip if the car with this license plate already exists
            if (await carRepository.ExistsByLicensePlateAsync(row.LicensePlateNumber, cancellationToken))
                continue;

            var car = new Repository.Entities.Car
            {
                Id = Guid.NewGuid(),
                Brand = row.Brand,
                LicensePlateNumber = row.LicensePlateNumber,
                NumberOfSeats = row.NumberOfSeats.Value
            };

            carsBuffer.Add(car);

            if (carsBuffer.Count >= BatchSize)
            {
                await carRepository.AddRangeAsync(carsBuffer, cancellationToken);
                carsBuffer.Clear();
            }
        }

        // Add any remaining records
        if (carsBuffer.Count > 0)
            await carRepository.AddRangeAsync(carsBuffer, cancellationToken);
    }
}
