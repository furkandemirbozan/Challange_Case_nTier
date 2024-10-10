using Shipping.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingDAL.Interfaces
{
    public interface ICarrierRepository: IRepository<Carrier>
    {
        Task<IEnumerable<Carrier>> GetAllCarriersAsync();
        Task<string> AddCarrierAsync(Carrier carrier);
        Task<string> UpdateCarrierAsync(Carrier carrier);
        Task<string> DeleteCarrierAsync(int carrierId);
    }
}
