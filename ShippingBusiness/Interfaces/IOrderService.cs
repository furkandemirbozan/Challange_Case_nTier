using Shipping.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingBusiness.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<string> AddOrderAsync(Order order);
        Task<string> DeleteOrderAsync(int orderId);
    }
}
