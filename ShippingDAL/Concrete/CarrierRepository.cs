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
    public class CarrierRepository : Repository<Carrier>, ICarrierRepository
    {
        private readonly AppDbContext _context;

        public CarrierRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Carrier>> GetAllCarriersAsync()
        {
            return await _context.Carriers.ToListAsync();
        }

        public async Task<string> AddCarrierAsync(Carrier carrier)
        {
            await _context.Carriers.AddAsync(carrier);
            await _context.SaveChangesAsync();
            return $"{carrier.Id} ID'li kargo firması eklendi.";
        }

        public async Task<string> UpdateCarrierAsync(Carrier carrier)
        {
            _context.Carriers.Update(carrier);
            await _context.SaveChangesAsync();
            return $"{carrier.Id} ID'li kargo firması güncellendi.";
        }

        public async Task<string> DeleteCarrierAsync(int carrierId)
        {
            var carrier = await _context.Carriers.FindAsync(carrierId);
            if (carrier == null)
            {
                return "Kargo firması bulunamadı.";
            }

            _context.Carriers.Remove(carrier);
            await _context.SaveChangesAsync();
            return $"{carrierId} ID'li kargo firması silindi.";
        }
    }
}
