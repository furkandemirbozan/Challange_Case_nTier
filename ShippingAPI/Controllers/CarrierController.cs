using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Core.DTOs;
using Shipping.Core.Models;
using ShippingBusiness.Interfaces;

namespace ShippingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService _carrierService;

        public CarrierController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarrierDTO>>> GetAllCarriers()
        {
            var carriers = await _carrierService.GetAllCarriersAsync();
            var carrierDtos = carriers.Select(carrier => new CarrierDTO
            {
                Id = carrier.Id,
                CarrierName = carrier.CarrierName,
                CarrierPlusDesiCost = carrier.CarrierPlusDesiCost,
                IsActive = carrier.IsActive
            }).ToList();
            return Ok(carrierDtos);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddCarrier([FromBody] CarrierDTO carrierDto)
        {
            var carrier = new Carrier
            {
                CarrierName = carrierDto.CarrierName,
                CarrierPlusDesiCost = carrierDto.CarrierPlusDesiCost,
                IsActive = carrierDto.IsActive,
                CreatedDate = DateTime.Now
            };

            var result = await _carrierService.AddCarrierAsync(carrier);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateCarrier([FromBody] CarrierDTO carrierDto)
        {
            var carrier = new Carrier
            {
                Id = carrierDto.Id,
                CarrierName = carrierDto.CarrierName,
                CarrierPlusDesiCost = carrierDto.CarrierPlusDesiCost,
                IsActive = carrierDto.IsActive,
                CreatedDate = DateTime.Now
            };

            var result = await _carrierService.UpdateCarrierAsync(carrier);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCarrier(int id)
        {
            var result = await _carrierService.DeleteCarrierAsync(id);

            return Ok(result);
        }
    }
}
