using AirLab;
using AirLab.Clients;
using AirLab.Data;
using AirLab.Infrastructure;
using AirLab.Repositories.PurpleAir.PurpleAirDatas;
using AirLab.Repositories.PurpleAir.PurpleAirSensors;
using AirLab.Services.PurpleAir;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Configuration;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<Seed>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IPurpleAirApiClient, PurpleAirApiClient>();

builder.Services.AddScoped<IPurpleAirSensorRepository, PurpleAirSensorRepository>();
builder.Services.AddScoped<IPurpleAirDataRepository, PurpleAirDataRepository>();
builder.Services.AddScoped<IPurpleAirService, PurpleAirService>();

builder.Services.AddHttpClient<IPurpleAirApiClient, PurpleAirApiClient>(client =>
{
    client.BaseAddress = new Uri("https://api.purpleair.com/v1/sensors/");
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();
builder.Services.AddInfrastructure();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
});

var app = builder.Build();
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
}

app.MapGet("/", () => "Hello Airlab!");

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
