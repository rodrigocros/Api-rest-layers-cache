using DEVinCar.Domain.Models;
using DEVinCar.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Interfaces.Services;
using AutoMapper;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/user")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ISaleService _saleService;


    public UserController(IUserService userService, IMapper mapper,ISaleService saleService )
    {
        _saleService = saleService;
       _userService = userService;
       _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<List<User>> Get(
       [FromQuery] string name,
       [FromQuery] DateTime? birthDateMax,
       [FromQuery] DateTime? birthDateMin
   )
    {
        var users = _userService.Get(name,birthDateMax,birthDateMin);
        var userDTO = _mapper.Map<IList<UserDTO>>(users);

        if (userDTO.Any())
        {
            return NoContent();
        }

        return Ok(userDTO);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetById(
        [FromRoute] int id
    )
    {
        var user = _userService.GetById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet("{userId}/buy")]
    public ActionResult <List<Sale>> GetByIdbuy(
       [FromRoute] int userId)

    {  
        var sales = _userService.GetBuyerByID(userId);
        var saleDTO = _mapper.Map<IList<SaleDTO>>(sales);


        if (saleDTO == null || saleDTO.Count() == 0)
        {
            return NoContent();
        }
        return Ok(saleDTO.ToList());
    }

    [HttpGet("{userId}/sales")]
    public ActionResult <List<Sale>> GetSalesBySellerId(
       [FromRoute] int userId)
    {
        var sales = _userService.GetSellerByID(userId);

        var saleDTO = _mapper.Map<IList<SaleDTO>>(sales);

        if (saleDTO == null || saleDTO.Count() == 0)
        {
            return NoContent();
        }
        return Ok(saleDTO.ToList());
    }

    [HttpPost]
    public ActionResult Post(
        [FromBody] UserDTO userDto
    )
    {
        var newUser = _mapper.Map<User>(userDto); 
        _userService.Inserir(newUser);
        
        return Created("api/users", newUser.Id);
    }

    [HttpPost("{userId}/sales")]
    public ActionResult<Sale> PostSaleUserId(
           [FromRoute] int userId,
           [FromBody] SaleDTO saleDTO)
    {
        var sale = _mapper.Map<Sale>(saleDTO);
        sale.SellerId = userId;

        _saleService.Inserir(sale);
        return Created("api/sale", sale.Id);
    }

    [HttpPost("{userId}/buy")]

   public ActionResult<Sale> PostBuyerUserId(
          [FromRoute] int sellerId,
          [FromBody] BuyDTO body)
    {
        var seller = _saleService.GetById(sellerId);
        // var user = _context.Users.Find(userId);

        if (seller == null)
        {
            return NotFound("The user does not exist!");
        }

        var buyer = _userService.GetSellerByID(body.SellerId);
        // var seller = _context.Users.Find(body.SellerId);
        if (buyer == null)
        {
            return NotFound("The user does not exist!");
        }

        //assim estava apresentando warning no builder
        //  if (body.SaleDate == null)
        // {
        //     body.SaleDate = DateTime.Now;
        // }

        if (body.SaleDate.ToString() != null)
        {
            body.SaleDate = DateTime.Now;
        }
 
        
        var buy = new Sale
        {
            BuyerId = seller.Id,
            SellerId = body.SellerId,
            SaleDate = body.SaleDate,
        };

        return Created("api/user/{userId}/buy", buy.Id);
    }
      

    [HttpDelete("{userId}")]
    public ActionResult Delete(
       [FromRoute] int userId
   )
    {
        var user = _userService.GetById(userId);
        if (user == null)
        {
            return NotFound();
        }
        _userService.Excluir(user);

        return NoContent();
    }


}





