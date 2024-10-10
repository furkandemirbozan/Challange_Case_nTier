using Shipping.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingBusiness.Interfaces
{
    public interface ICarrierConfigurationService
    {
        Task<IEnumerable<CarrierConfiguration>> GetAllCarrierConfigurationsAsync();
        Task<string> AddCarrierConfigurationAsync(CarrierConfiguration configuration);
        Task<string> UpdateCarrierConfigurationAsync(CarrierConfiguration configuration);
        Task<string> DeleteCarrierConfigurationAsync(int configurationId);
    }
}
