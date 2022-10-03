using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Api.Service;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers
{   
    [AllowAnonymous]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly ILoginService   _loginService;
        public AutenticationController(ILoginService   loginService)
        {
            _loginService = loginService;   
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginDTO userloginDTO){

            var user = _loginService.ObterPorUsuarioESenha(userloginDTO.Email, userloginDTO.Password);

            if(user == null) return Unauthorized();

            var tokem = TokenService.GenerateTokem(user);

            return Ok(tokem); }

    }
}