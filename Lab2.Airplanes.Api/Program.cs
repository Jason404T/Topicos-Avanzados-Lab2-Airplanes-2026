using Lab2.Airplanes.Api.Application.Interfaces;
using Lab2.Airplanes.Api.Application.Services;
using Lab2.Airplanes.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<IAirplaneRepository, InMemoryAirplaneRepository>();
builder.Services.AddScoped<AirplaneService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
