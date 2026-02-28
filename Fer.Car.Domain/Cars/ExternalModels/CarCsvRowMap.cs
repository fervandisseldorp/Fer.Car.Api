using CsvHelper.Configuration;

namespace Fer.Car.Domain.Cars.ExternalModels;

public sealed class CarCsvRowMap : ClassMap<CarCsvRow>
{
    public CarCsvRowMap()
    {
        Map(m => m.Brand).Name("Merk");
        Map(m => m.LicensePlateNumber).Name("Kenteken");
        Map(m => m.NumberOfSeats).Name("Aantal zitplaatsen");
    }
}
