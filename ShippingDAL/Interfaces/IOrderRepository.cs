using Shipping.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingDAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order> 
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<string> AddOrderAsync(Order order);
        Task<string> DeleteOrderAsync(int orderId);
    }
}
