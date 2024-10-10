using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Core.DTOs
{
    public class CarrierConfigurationDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int CarrierId { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}
