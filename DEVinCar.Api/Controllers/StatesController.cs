using DEVinCar.Domain.Models;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Interfaces.Services;
using AutoMapper;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/state")]
public class StatesController : ControllerBase
{
    private readonly IStateService _stateservice;
    private readonly IMapper _mapper;


    public StatesController(IStateService stateservice, IMapper mapper)
    {
        _stateservice = stateservice;
        _mapper = mapper;
    }

    [HttpPost("{stateId}/city")]
    public ActionResult<int> PostCity(
        [FromRoute] int stateId,
        [FromBody] CityDTO cityDTO
    )
    {
        var state = _stateservice.GetById(stateId);
        // var state = _context.States.Find(stateId);

        if (state == null)
        {
            return NotFound();
        }
        var city = _stateservice.GetCitiesByName(cityDTO.Name);
        // if (_context.Cities.Any(c => c.StateId == state.Id && c.Name == cityDTO.Name))
        if(state.Id == stateId && state.Name == city.Name)
        {
            return BadRequest();
        }

        var newCity = new City
        {
            Name = cityDTO.Name,
            StateId = stateId,
        };

        _stateservice.InserirOnCity(newCity);

        // _context.Cities.Add(city);
        // _context.SaveChanges();

        return Created("api/{stateId}/city", newCity.Id);
    }

    [HttpPost("{stateId}/city/{cityId}/address")]
    public ActionResult<int> PostAdress(
        [FromRoute] int stateId,
        [FromRoute] int cityId,
        [FromBody] AdressDTO body)
    {
        var idState = _stateservice.GetById(stateId);
        // var idState = _context.States.Find(stateId);

        var idCity = _stateservice.GetCityById(cityId);

        // var idCity = _context.Cities.Find(cityId);

        if (idState == null || idCity == null)
        {
            return NotFound();
        }

        if (idCity.StateId != idState.Id)
        {
            return BadRequest();
        }

        var address = new Address
        {
            CityId = cityId,
            Street = body.Street,
            Number = body.Number,
            Cep = body.Cep,
            Complement = body.Complement,
            City = idCity

        };
        // _context.Addresses.Add(address);
        // _context.SaveChanges();

        _stateservice.InsertOnAdress(address);

        return Created($"api/state/{stateId}/city/{cityId}/", address.Id);
    }

    [HttpGet("{stateId}/city/{cityId}")]

    public ActionResult<GetCityByIdViewModel> GetCityById
    (
        [FromRoute] int stateId,
        [FromRoute] int cityId
    )
    {
        var idState = _stateservice.GetById(stateId);
        // var idState = _context.States.Find(stateId);
        var idCity = _stateservice.GetCityById(cityId);
        // var idCity = _context.Cities.Find(cityId);

        if (idState == null || idCity == null)
        {
            return NotFound();
        }

        if (idCity.StateId != idState.Id)
        {
            return BadRequest();
        }

        GetCityByIdViewModel body = new GetCityByIdViewModel(
            idCity.Id,
            idCity.Name,
            idState.Id,
            idState.Name,
            idState.Initials
        );

        return Ok(body);
    }

    [HttpGet("{stateId}")]
    public ActionResult<GetStateByIdViewModel> GetStateById(
            [FromRoute] int stateId
        )
    {
        var filterState = _stateservice.GetById(stateId);
        // var filterState = _context.States.Find(stateId);
        if (filterState == null)
        {
            return NotFound("There is no given with this id");
        }

        var response = new GetStateByIdViewModel(
            filterState.Id,
            filterState.Name,
            filterState.Initials
            );
       
        return Ok(response);
    }

    [HttpGet("{ByName}")]
    public ActionResult<State> Get([FromQuery] string name) {

        return _stateservice.GetStatebyName(name);

    }

    [HttpGet("{stateId}/city")]
    public ActionResult<GetCityByIdViewModel> GetCityByStateId(
        [FromRoute] int stateId,
        [FromQuery] string name
       )
    
    {
        var state = _stateservice.GetById(stateId);
        // var state = _context.States.Find(stateId);
        // var cityStates = _context.Cities.Where(c => c.StateId == state.Id);
        var cityStates = _stateservice.GetCitiesByName(name);
        
        
        if (state == null){
            return NotFound("State not found.");
        }
        
        if (cityStates == null){
            return NotFound("City not found.");
        }


        var queryResponse =  new GetCityByIdViewModel(cityStates.Id,cityStates.Name,state.Id,state.Name,state.Initials);

        return Ok(queryResponse);    
        

    }

}

