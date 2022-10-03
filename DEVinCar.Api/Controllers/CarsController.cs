
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Interfaces.Services;
using AutoMapper;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IMapper _mapper;


    public CarController(ICarService carService, IMapper mapper)
    {
        _carService = carService;
        _mapper = mapper;
    }

    [HttpGet("{carId}")]
    public ActionResult<Car> GetById([FromRoute] int carId)
    {
        var car = _carService.GetById(carId);
        // var car = _context.Cars.Find(carId);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet]
    public ActionResult<List<Car>> Get(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax
    )
    {
        var carList =  _carService.GetFiltered(name,priceMin,priceMax);
        var carListDTO = _mapper.Map<CarDTO>(carList);
        return Ok(carListDTO);
    }

    [HttpPost]
    public ActionResult<Car> Post(
        [FromBody] CarDTO body
    )
    {
        var carList = _carService.Get();

        if (carList.Any(c => c.Name == body.Name || body.SuggestedPrice <= 0))
        {
            return BadRequest();
        }
        var car = new Car
        {
            Name = body.Name,
            SuggestedPrice = body.SuggestedPrice,
        };
        // _context.Cars.Add(car);
        // _context.SaveChanges();
        _carService.Inserir(car);
        return Created("api/car", car);
    }

    [HttpDelete("{carId}")]
    public ActionResult Delete([FromRoute] int carId)
    {
        // var car = _context.Cars.Find(carId);
        var car = _carService.GetById(carId);
        // var soldCar = _context.SaleCars.Any(s => s.CarId == carId);
        var soldCar = _carService.GetSaleCarPorId(carId);
        if (car == null)
        {
            return NotFound();
        }
        if (soldCar == null)
        {
            return BadRequest();
        }
        // _context.Remove(car);
        // _context.SaveChanges();

        _carService.Excluir(car);
        return NoContent();
    }

    [HttpPut("{carId}")]
    public ActionResult<Car> Put([FromBody] CarDTO carDto, [FromRoute] int carId)
    {
        // var car = _context.Cars.Find(carId);
        var car = _carService.GetById(carId);
        // var name = _context.Cars.Any(c => c.Name == carDto.Name && c.Id != carId);
        var name = _carService.Get().FirstOrDefault(c => c.Name == carDto.Name && c.Id != carId );


        if (car == null)
            return NotFound();
        if (carDto.Name.Equals(null) || carDto.SuggestedPrice.Equals(null))
            return BadRequest();
        if (carDto.SuggestedPrice <= 0)
            return BadRequest();
        
        car.Name = carDto.Name;
        car.SuggestedPrice = carDto.SuggestedPrice;

        // _context.SaveChanges();
        _carService.Inserir(car);
        return NoContent();
    }
}
