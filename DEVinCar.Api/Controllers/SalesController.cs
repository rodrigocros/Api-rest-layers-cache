using System.Linq;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    private readonly IDeliveryService _deliveryService;
    private readonly ISaleCarService _saleCarService;
    private readonly ICarService _carService;
    private readonly ISaleService _saleservice;
    private readonly IMapper _mapper;

    public SalesController(ISaleService saleservice, IMapper mapper, ICarService carService, ISaleCarService saleCarService, IDeliveryService deliveryService)
    {
        _saleservice = saleservice;
        _mapper = mapper;
        _carService = carService;
        _saleCarService = saleCarService;
        _deliveryService = deliveryService;

    }

    [HttpGet("{saleId}")]
    public ActionResult<List<SaleDTO>> GetItensSale(
        [FromRoute] int saleId)
    {   
        var sales = _saleCarService.GetById(saleId);
        if (sales == null) return NotFound();

        var saleCarDTO = _mapper.Map<List<SaleCarDTO>>(sales);
        return Ok(saleCarDTO);
    }

    [Authorize(Roles = "Gerente")]
    [HttpPost("{saleId}/item")]
    public ActionResult<SaleCar> PostSale(
       [FromBody] SaleCarDTO body,
       [FromRoute] int saleId
       )
    {
        decimal unitPrice;
        var carDTO = _carService.GetById(body.CarId);
        var carSALE = _saleservice.GetById(body.SaleId);

        // if (_context.Cars.Any(c => c.Id == body.CarId) && _context.Sales.Any(s => s.Id == body.SaleId))
        if(carDTO != null && carSALE != null)
        {
            if (body.CarId == 0) return BadRequest();

            if (body.UnitPrice <= 0 || body.Amount <= 0) return BadRequest();

            if (body.UnitPrice == null) unitPrice =  carDTO.SuggestedPrice;

            else unitPrice = (decimal)body.UnitPrice;

            if (body.Amount == null) body.Amount = 1;

            var saleCar = new SaleCar
            {
                Id = saleId,
                Amount = body.Amount,
                CarId = body.CarId,
                UnitPrice = unitPrice,
                SaleId = saleId
            };

            // _context.SaleCars.Add(saleCar);
            // _context.SaveChanges();
            _saleCarService.Inserir(saleCar);
            
            return Created("api/sales/{saleId}/item", saleCar);
        }
        return NotFound();
    }

    [HttpPost("{saleId}/deliver")]
    public ActionResult<DeliveryDTO> PostDeliver(
           [FromRoute] int saleId,
           [FromBody] DeliveryDTO body)
    {

        if (!body.AddressId.HasValue)
        {
            return BadRequest();
        }

        // if (_context.Sales.Find(saleId) == null)
        if(_saleservice.GetById(saleId) == null)
        {
            return NotFound();
        }

        // funcao sem sentido, nao tem adressID no repositorio Sale. Nao entendi.
        // if (_context.Sales.Find(body.AddressId) == null)
        // if(_saleservice.GetById(body.AddressId) == null)
        // {
        //     return NotFound();
        // }

        var now = DateTime.Now.Date;
        if (body.DeliveryForecast < now)
        {
            return BadRequest();
        }

        if (body.DeliveryForecast == null)
        {
            body.DeliveryForecast = DateTime.Now.AddDays(7);
        }

        var deliver = new Delivery
        {
            AddressId = (int)body.AddressId,
            SaleId = saleId,
            DeliveryForecast = (DateTime)body.DeliveryForecast
        };

        _deliveryService.Inserir(deliver);
        // _context.Deliveries.Add(deliver);
        // _context.SaveChanges();

        return Created("{saleId}/deliver", deliver.Id);
    }

}

