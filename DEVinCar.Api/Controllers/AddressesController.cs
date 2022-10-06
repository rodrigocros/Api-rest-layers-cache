using DEVinCar.Domain.Models;
using DEVinCar.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.Interfaces.Services;
using AutoMapper;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/address")]

public class AddressesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAddressService _adressService;
    private readonly IDeliveryService _deliveryService;

    public AddressesController(IAddressService adressService, IMapper mapper, IDeliveryService deliveryService)
    {
        _adressService = adressService;
        _mapper = mapper;
        _deliveryService = deliveryService;
    }

    [HttpGet]
    public ActionResult<List<AddressViewModel>> Get([FromQuery] int? cityId,
                                                    [FromQuery] int? stateId,
                                                    [FromQuery] string street,
                                                    [FromQuery] string cep)
    {
        var query = _adressService.GetList(cityId,stateId,street,cep);
        return Ok(query);

    }

    [HttpPost]
    public ActionResult<Address> Insert([FromBody]int id, int cityId, string street,string cep, int number ,string complement ){
        var address = new Address(id,cityId,street,cep, number,complement);
        _adressService.Inserir(address);
        return Ok(address);
    }
    

    [HttpDelete("{addressId}")]

    public ActionResult DeleteById([FromRoute] int addressId)
    {
        var address = _adressService.GetById(addressId);
        // Address address = _context.Addresses.Find(addressId);

        if (address == null)
        {
            return NotFound($"The address with ID: {addressId} not found.");
        }

        // var relation = _context.Deliveries.FirstOrDefault(d => d.AddressId == addressId);
        var relation = _deliveryService.GetById(addressId);

        if (relation != null)
        {
            return BadRequest($"The address with ID: {addressId} is related to a delivery.");
        }
        _adressService.Excluir(address);

        return NoContent();
    }
}
