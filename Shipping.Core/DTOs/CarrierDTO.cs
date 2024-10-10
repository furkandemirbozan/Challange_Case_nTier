using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Core.DTOs
{
    public class CarrierDTO
    {
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public int CarrierPlusDesiCost { get; set; } 
        public bool IsActive { get; set; }
    }
}
