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
    public class CarrierService : ICarrierService
    {
        private readonly ICarrierRepository _carrierRepository;

        public CarrierService(ICarrierRepository carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }

        public async Task<IEnumerable<Carrier>> GetAllCarriersAsync()
        {
            return await _carrierRepository.GetAllCarriersAsync();
        }

        public async Task<string> AddCarrierAsync(Carrier carrier)
        {
            return await _carrierRepository.AddCarrierAsync(carrier);
        }

        public async Task<string> UpdateCarrierAsync(Carrier carrier)
        {
            return await _carrierRepository.UpdateCarrierAsync(carrier);
        }

        public async Task<string> DeleteCarrierAsync(int carrierId)
        {
            return await _carrierRepository.DeleteCarrierAsync(carrierId);
        }
    }
}
