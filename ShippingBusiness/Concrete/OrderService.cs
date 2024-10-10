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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;

        public OrderService(IOrderRepository orderRepository, ICarrierConfigurationRepository carrierConfigurationRepository)
        {
            _orderRepository = orderRepository;
            _carrierConfigurationRepository = carrierConfigurationRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<string> AddOrderAsync(Order order)
        {
            // 1. Sipariş desisi herhangi bir kargo firmasının MinDesi-MaxDesi aralığına giriyor mu?
            var carrierConfigurations = await _carrierConfigurationRepository
                .GetAllCarrierConfigurationsAsync();

            var suitableConfigurations = carrierConfigurations
                .Where(cc => order.OrderDesi >= cc.CarrierMinDesi && order.OrderDesi <= cc.CarrierMaxDesi)
                .OrderBy(cc => cc.CarrierCost)
                .ToList();

            if (suitableConfigurations.Any())
            {
                // En düşük ücrete sahip olan kargo firması seçiliyor
                var selectedConfiguration = suitableConfigurations.First();
                order.OrderCarrierCost = selectedConfiguration.CarrierCost;
                order.CarrierId = selectedConfiguration.CarrierId;
            }
            else
            {
                // 2. En yakın desi aralığına göre hesaplama
                var closestConfiguration = carrierConfigurations
                    .OrderBy(cc => Math.Abs(order.OrderDesi - cc.CarrierMaxDesi))
                    .FirstOrDefault();

                if (closestConfiguration != null)
                {
                    int desiDifference = order.OrderDesi - closestConfiguration.CarrierMaxDesi;
                    decimal extraCost = desiDifference * closestConfiguration.Carrier.CarrierPlusDesiCost;
                    order.OrderCarrierCost = closestConfiguration.CarrierCost + extraCost;
                    order.CarrierId = closestConfiguration.CarrierId;
                }
            }

            // Sipariş veritabanına ekleniyor
            return await _orderRepository.AddOrderAsync(order);
        }

        public async Task<string> DeleteOrderAsync(int orderId)
        {
            return await _orderRepository.DeleteOrderAsync(orderId);
        }
    }
}
