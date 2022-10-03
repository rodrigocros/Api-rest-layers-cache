using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Annotations;

namespace DEVinCar.Domain.DTOs
{
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }      
    }
}