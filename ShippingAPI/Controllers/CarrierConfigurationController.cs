using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Core.DTOs;
using Shipping.Core.Models;
using ShippingBusiness.Interfaces;

namespace ShippingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;

        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarrierConfigurationDTO>>> GetAllCarrierConfigurations()
        {
            var configurations = await _carrierConfigurationService.GetAllCarrierConfigurationsAsync();
            var configurationDtos = configurations.Select(configuration => new CarrierConfigurationDTO
            {
                Id = configuration.Id,
                CarrierId = configuration.CarrierId,
                CarrierMaxDesi = configuration.CarrierMaxDesi,
                CarrierMinDesi = configuration.CarrierMinDesi,
                CarrierCost = configuration.CarrierCost,
                IsActive = configuration.IsActive
            }).ToList();
            return Ok(configurationDtos);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddCarrierConfiguration([FromBody] CarrierConfigurationDTO configurationDto)
        {
            var configuration = new CarrierConfiguration
            {
                CarrierId = configurationDto.CarrierId,
                CarrierMaxDesi = configurationDto.CarrierMaxDesi,
                CarrierMinDesi = configurationDto.CarrierMinDesi,
                CarrierCost = configurationDto.CarrierCost,
                IsActive = configurationDto.IsActive,
                CreatedDate = DateTime.Now
            };

            var result = await _carrierConfigurationService.AddCarrierConfigurationAsync(configuration);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateCarrierConfiguration([FromBody] CarrierConfigurationDTO configurationDto)
        {
            var configuration = new CarrierConfiguration
            {
                Id = configurationDto.Id,
                CarrierId = configurationDto.CarrierId,
                CarrierMaxDesi = configurationDto.CarrierMaxDesi,
                CarrierMinDesi = configurationDto.CarrierMinDesi,
                CarrierCost = configurationDto.CarrierCost,
                IsActive = configurationDto.IsActive,
                CreatedDate = DateTime.Now
            };

            var result = await _carrierConfigurationService.UpdateCarrierConfigurationAsync(configuration);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCarrierConfiguration(int id)
        {
            var result = await _carrierConfigurationService.DeleteCarrierConfigurationAsync(id);
            return Ok(result);
        }
    }
}
