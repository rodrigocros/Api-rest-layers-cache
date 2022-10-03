using System;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs
{
    public class BuyDTO
    {
        [Required(ErrorMessage = "The SellerId is required.")]
        public int SellerId{ get; set; }
        public DateTime SaleDate { get; set; }
    }
}


