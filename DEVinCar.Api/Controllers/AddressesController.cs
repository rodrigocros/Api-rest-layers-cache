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

    // [HttpPatch("{addressId}")]
    // public ActionResult<AddressViewModel> Patch([FromRoute] int addressId,
    //                                    [FromBody] AddressPatchDTO addressPatchDTO)
    // {

    //     // Address address = _context.Addresses.Include(a => a.City).FirstOrDefault(a => a.Id == addressId);
    //      Address address = _adressService.GetById(addressId);

    //     if (address == null)
    //         return NotFound($"The address with ID: {addressId} not found.");

    //     string street = addressPatchDTO.Street ?? null;
    //     string cep = addressPatchDTO.Cep ?? null;
    //     string complement = addressPatchDTO.Complement ?? null;

    //     if (street != null)
    //     {
    //         if (addressPatchDTO.Street == "")
    //             return BadRequest("The street name cannot be empty.");
    //         address.Street = street;
    //     }

    //     if (addressPatchDTO.Cep != null)
    //     {
    //         if (addressPatchDTO.Cep == "")
    //             return BadRequest("The cep cannot be empty.");
    //         if (!addressPatchDTO.Cep.All(char.IsDigit))
    //             return BadRequest("Every characters in cep must be numeric.");
    //         address.Cep = cep;
    //     }

    //     if (addressPatchDTO.Complement != null)
    //     {
    //         if (addressPatchDTO.Complement == "")
    //             return BadRequest("The complement cannot be empty.");
    //         address.Complement = complement;
    //     }

    //     if (addressPatchDTO.Number != 0)
    //         address.Number = addressPatchDTO.Number;

    //     _context.SaveChanges();

    //     AddressViewModel addressViewModel = new AddressViewModel(
    //         address.Id,
    //         address.Street,
    //         address.CityId,
    //         address.City.Name,
    //         address.Number,
    //         address.Complement,
    //         address.Cep
    //     );
    //     return Ok(addressViewModel);
    // }

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

        return NoContent();
    }
}
