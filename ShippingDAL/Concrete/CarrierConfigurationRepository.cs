using Microsoft.EntityFrameworkCore;
using Shipping.Core.Models;
using ShippingDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingDAL.Concrete
{
    public class CarrierConfigurationRepository : Repository<CarrierConfiguration>, ICarrierConfigurationRepository
    {
        private readonly AppDbContext _context;

        public CarrierConfigurationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarrierConfiguration>> GetAllCarrierConfigurationsAsync()
        {
            return await _context.CarrierConfigurations.ToListAsync();
        }

        public async Task<string> AddCarrierConfigurationAsync(CarrierConfiguration configuration)
        {
            await _context.CarrierConfigurations.AddAsync(configuration);
            await _context.SaveChangesAsync();
            return $"{configuration.Id} ID'li kargo firması konfigürasyonu eklendi.";
        }

        public async Task<string> UpdateCarrierConfigurationAsync(CarrierConfiguration configuration)
        {
            _context.CarrierConfigurations.Update(configuration);
            await _context.SaveChangesAsync();
            return $"{configuration.Id} ID'li kargo firması konfigürasyonu güncellendi.";
        }

        public async Task<string> DeleteCarrierConfigurationAsync(int configurationId)
        {
            var configuration = await _context.CarrierConfigurations.FindAsync(configurationId);
            if (configuration == null)
            {
                return "Kargo firması konfigürasyonu bulunamadı.";
            }

            _context.CarrierConfigurations.Remove(configuration);
            await _context.SaveChangesAsync();
            return $"{configurationId} ID'li kargo firması konfigürasyonu silindi.";
        }
    }
}
