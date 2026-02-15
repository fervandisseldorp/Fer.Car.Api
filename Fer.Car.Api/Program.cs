using DotNetEnv;
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
dataSourceBuilder.UseVector();
var dataSource = dataSourceBuilder.Build();

builder.Services.AddSingleton<NpgsqlDataSource>(dataSource);

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();


app.Run();
