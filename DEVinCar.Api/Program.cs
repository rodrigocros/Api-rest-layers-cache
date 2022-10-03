using System.Text.Json.Serialization;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Service;
using DEVinCar.Di;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCar.Api.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DEVinCar.Domain.Security;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

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

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(_x_ =>{

    _x_.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    _x_.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;})

.AddJwtBearer(_x_ =>{

    _x_.RequireHttpsMetadata = false;

    _x_.SaveToken = true;

    _x_.TokenValidationParameters = new TokenValidationParameters {

        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(key),

        ValidateIssuer = false,

        ValidateAudience = false };});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(config =>
    {
        config.ReturnHttpNotAcceptable = true;
        config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
        config.InputFormatters.Add(new XmlSerializerInputFormatter(config));

    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErroMiddleware>();

app.Run();
