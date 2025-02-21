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
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddCors(
    options => {
        options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

var app = builder.Build();




app.UseCors("AllowAllOrigins");
app.MapControllers();
app.MapGet("/", () => "Poke Liga API ");

app.Run();
