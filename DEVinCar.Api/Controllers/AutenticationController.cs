using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Api.Service;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DEVinCar.Api.Controllers
{   
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AutenticationController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        public AutenticationController(IAddressService addressService,IUserService userService)
        {
            
            _addressService = addressService;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginDTO userloginDTO){

            var user = _userService.ObterPorUsuarioESenha(userloginDTO);

            if(user == null) return Unauthorized();

            var tokem = TokenService.GenerateToken(user);
            var refreshToken = TokenService.GenerateRefreshToken();
            TokenService.SaveRefreshToken(user.Email,refreshToken);
 
            return Ok( new {tokem, refreshToken}
            ); 
        }

        [HttpPost]
        [Route("refresh")]
        [AllowAnonymous]
        public IActionResult RefreshToken([FromQuery] string token, [FromQuery] string refreshToken)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var savedRefreshToken = TokenService.GetRefreshToken(username);

            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newToken = TokenService.GenerateToken(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();
            TokenService.DeleteRefreshToken(username, refreshToken);
            TokenService.SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newToken,
                refreshToken = newRefreshToken
                
            });

        
        }
        // [HttpGet]
        // [Route("list-refresh-tokens")]
        // public IActionResult ListRefreshTokens(){
        //     return Ok(TokenService.GetAllRefreshTokens());
        // }

    }
}