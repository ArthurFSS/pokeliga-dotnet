using Microsoft.EntityFrameworkCore;
using Pokeliga.Api.Infra;
using Pokeliga.Api.Interfaces;
using Pokeliga.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(connectionString)
    );

builder.Services.AddScoped<ILigaService, LigaService>();
builder.Services.AddScoped<IImportService, ImportService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
