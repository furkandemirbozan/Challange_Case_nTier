using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }
    }
}
