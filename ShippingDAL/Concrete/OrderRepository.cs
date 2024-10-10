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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o => o.Carrier).ToListAsync();
        }

        public async Task<string> AddOrderAsync(Order order)
        {
            var carrierConfigurations = await _context.CarrierConfigurations
                .Where(cc => order.OrderDesi >= cc.CarrierMinDesi && order.OrderDesi <= cc.CarrierMaxDesi)
                .OrderBy(cc => cc.CarrierCost)
                .ToListAsync();

            if (carrierConfigurations.Any())
            {
                // En uygun kargo firmasını seç
                var selectedCarrierConfiguration = carrierConfigurations.First();
                order.OrderCarrierCost = selectedCarrierConfiguration.CarrierCost;
                order.CarrierId = selectedCarrierConfiguration.CarrierId;
            }
            else
            {
                // En yakın desi aralığına göre hesaplama
                var closestCarrierConfiguration = await _context.CarrierConfigurations
                    .OrderBy(cc => Math.Abs(order.OrderDesi - cc.CarrierMaxDesi))
                    .FirstOrDefaultAsync();

                if (closestCarrierConfiguration != null)
                {
                    int desiFark = order.OrderDesi - closestCarrierConfiguration.CarrierMaxDesi;
                    decimal extraCost = desiFark * closestCarrierConfiguration.Carrier.CarrierPlusDesiCost;
                    order.OrderCarrierCost = closestCarrierConfiguration.CarrierCost + extraCost;
                    order.CarrierId = closestCarrierConfiguration.CarrierId;
                }
            }

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return $"{order.Id} ID'li sipariş eklendi.";
        }

        public async Task<string> DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return "Sipariş bulunamadı.";
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return $"{orderId} ID'li sipariş silindi.";
        }
    }
}
