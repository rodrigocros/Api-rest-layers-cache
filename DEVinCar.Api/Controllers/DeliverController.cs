using DEVinCar.Domain.Models;
using DEVinCar.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.ConstrainedExecution;
using DEVinCar.Domain.Interfaces.Services;
using AutoMapper;

namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("api/deliver")]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliveryService _deliveryservice;
        private readonly IMapper _mapper;

        public DeliverController(IDeliveryService deliveryservice, IMapper mapper)
        {
            _deliveryservice = deliveryservice;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<Delivery> Get(
        [FromQuery] int? addressId,
        [FromQuery] int? saleId)
        {
            var query = _deliveryservice.Get(saleId,addressId);
            return Ok(query.ToList());
        }
    }
}

