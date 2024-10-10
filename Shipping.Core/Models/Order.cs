using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Core.Models
{
    public class Order : BaseEntity
    {
        [Required]
        [ForeignKey("Carrier")]
        public int CarrierId { get; set; } // Kargo firması ID'si
        [Required]
        public int OrderDesi { get; set; } // Siparişin desi miktarı
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now; // Sipariş tarihi
        [Required]
        public decimal OrderCarrierCost { get; set; } // Kargo ücreti

        // Navigation Property
        public Carrier Carrier { get; set; }// n to 1 ilişki
    }
}
