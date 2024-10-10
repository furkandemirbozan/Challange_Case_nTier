using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Core.Models
{
    public class CarrierConfiguration : BaseEntity
    {
        [Required]
        [ForeignKey("Carrier")]
        public int CarrierId { get; set; }

        [Required]
        public int CarrierMaxDesi { get; set; } // Maksimum desi aralığı

        [Required]
        public int CarrierMinDesi { get; set; } // Minimum desi aralığı

        [Required]
        public decimal CarrierCost { get; set; } // Bu desi aralığındaki kargo ücreti

        // Navigation Property
        public Carrier Carrier { get; set; } // N'e 1 ilişki
    }
}
