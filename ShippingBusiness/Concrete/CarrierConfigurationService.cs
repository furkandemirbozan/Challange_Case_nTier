using Shipping.Core.Models;
using ShippingBusiness.Interfaces;
using ShippingDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingBusiness.Concrete
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;

        public CarrierConfigurationService(ICarrierConfigurationRepository carrierConfigurationRepository)
        {
            _carrierConfigurationRepository = carrierConfigurationRepository;
        }

        public async Task<IEnumerable<CarrierConfiguration>> GetAllCarrierConfigurationsAsync()
        {
            return await _carrierConfigurationRepository.GetAllCarrierConfigurationsAsync();
        }

        public async Task<string> AddCarrierConfigurationAsync(CarrierConfiguration configuration)
        {
            return await _carrierConfigurationRepository.AddCarrierConfigurationAsync(configuration);
        }

        public async Task<string> UpdateCarrierConfigurationAsync(CarrierConfiguration configuration)
        {
            return await _carrierConfigurationRepository.UpdateCarrierConfigurationAsync(configuration);
        }

        public async Task<string> DeleteCarrierConfigurationAsync(int configurationId)
        {
            return await _carrierConfigurationRepository.DeleteCarrierConfigurationAsync(configurationId);
        }
    }
}
