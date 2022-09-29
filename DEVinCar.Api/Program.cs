using System.Text.Json.Serialization;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Service;
using DEVinCar.Di;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCar.Api.Config;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<DevInCarDbContext>();

// builder.Services.AddScoped<IAddressResitory, AddressRepository>();
// builder.Services.AddScoped<ICarRepository, CarRepository>();
// builder.Services.AddScoped<ICityRepository, CityRepository>();
// builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
// builder.Services.AddScoped<ISaleCarRepository, SaleCarRepository>();
// builder.Services.AddScoped<ISaleRepository, SaleRepository>();
// builder.Services.AddScoped<IStateRepository, StateRepository>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.Register();

builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<ISaleCarService, SaleCarService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStateService, StateService>();


builder.Services.AddSingleton(AutoMapperConfiguration.Configure());


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
