using DotNetEnv;
using Fer.Car.Domain.Cars;
using Fer.Car.Repository;
using Microsoft.EntityFrameworkCore;
using Npgsql;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

string connString =
$@"Host=cars-postgresql.postgres.database.azure.com;
Username=fer;
Password=Welkom01!;
Database=postgres;
SSL Mode=Require;";

var dataSourceBuilder = new NpgsqlDataSourceBuilder(connString);
var dataSource = dataSourceBuilder.Build();

builder.Services.AddSingleton<NpgsqlDataSource>(dataSource);
builder.Services.AddControllers();

// register domain services from domain project
builder.Services.AddCarServices();
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();

app.Run();
