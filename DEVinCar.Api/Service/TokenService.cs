using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.Security;
using Microsoft.IdentityModel.Tokens;

namespace DEVinCar.Api.Service
{
    public static class TokenService
    {
        public static string GenerateTokem(User user){
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor

            {

                Subject = new ClaimsIdentity(new Claim[]

                {

                    new Claim(ClaimTypes.Name, user.Name),

                    new Claim(ClaimTypes.Role, user.Password),

                }),

                Expires = DateTime.UtcNow.AddHours(2),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}