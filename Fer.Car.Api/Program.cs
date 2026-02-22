using DotNetEnv;
using Npgsql;
using Fer.Car.Domain.Cars;
using Fer.Car.Repository;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

string connString =
$@"Host=cars-postgresql.postgres.database.azure.com;
Username=fer;
Password=Welkom01!;
Database=postgres;
SSL Mode=Require;";

var dataSourceBuilder = new NpgsqlDataSourceBuilder(connString);
dataSourceBuilder.UseVector();
var dataSource = dataSourceBuilder.Build();

builder.Services.AddSingleton<NpgsqlDataSource>(dataSource);
builder.Services.AddControllers();

// register domain services from domain project
builder.Services.AddCarServices();
builder.Services.AddRepositories();

var app = builder.Build();
app.MapControllers();

app.Run();
