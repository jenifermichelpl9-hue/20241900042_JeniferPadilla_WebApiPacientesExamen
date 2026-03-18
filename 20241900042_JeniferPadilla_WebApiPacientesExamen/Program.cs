using _20241900042_JeniferPadilla_WebApiPacientesExamen.Features.Pacientes;
using _20241900042_JeniferPadilla_WebApiPacientesExamen.Infrastructure;
using _20241900042_JeniferPadilla_WebApiPacientesExamen.Repositories;
using _20241900042_JeniferPadilla_WebApiPacientesExamen.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Entity Framework Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Dependency Injection
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<PacientesDomainService>();
builder.Services.AddScoped<PacienteAppService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
