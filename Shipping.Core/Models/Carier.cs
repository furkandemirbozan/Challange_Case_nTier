using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Core.Models
{
    public class Carrier : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string CarrierName { get; set; }
        [Required]
        public int CarrierPlusDesiCost { get; set; } // +1 desi ücreti
        public int CarrierConfigurationId { get; set; } // Konfigürasyon için foreign key

        public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; }
    }
}
