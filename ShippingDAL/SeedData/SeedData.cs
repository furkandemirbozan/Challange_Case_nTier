using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shipping.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingDAL.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Carriers.Any() || context.CarrierConfigurations.Any() || context.Orders.Any())
                {
                    return; // Data already exists
                }

                // Seed Carriers
                var carriers = new List<Carrier>
                {
                    new Carrier { CarrierName = "FastCargo", CarrierPlusDesiCost = 5, IsActive = true, CreatedDate = DateTime.Now },
                    new Carrier { CarrierName = "SafeDelivery", CarrierPlusDesiCost = 7, IsActive = true, CreatedDate = DateTime.Now },
                    new Carrier { CarrierName = "QuickShip", CarrierPlusDesiCost = 6, IsActive = true, CreatedDate = DateTime.Now }
                };
                context.Carriers.AddRange(carriers);

                // Seed CarrierConfigurations
                var carrierConfigurations = new List<CarrierConfiguration>
                {
                    new CarrierConfiguration { CarrierId = 1, CarrierMinDesi = 1, CarrierMaxDesi = 10, CarrierCost = 30, IsActive = true, CreatedDate = DateTime.Now },
                    new CarrierConfiguration { CarrierId = 1, CarrierMinDesi = 11, CarrierMaxDesi = 20, CarrierCost = 50, IsActive = true, CreatedDate = DateTime.Now },
                    new CarrierConfiguration { CarrierId = 2, CarrierMinDesi = 1, CarrierMaxDesi = 15, CarrierCost = 40, IsActive = true, CreatedDate = DateTime.Now },
                    new CarrierConfiguration { CarrierId = 2, CarrierMinDesi = 16, CarrierMaxDesi = 25, CarrierCost = 60, IsActive = true, CreatedDate = DateTime.Now },
                    new CarrierConfiguration { CarrierId = 3, CarrierMinDesi = 1, CarrierMaxDesi = 12, CarrierCost = 35, IsActive = true, CreatedDate = DateTime.Now },
                    new CarrierConfiguration { CarrierId = 3, CarrierMinDesi = 13, CarrierMaxDesi = 22, CarrierCost = 55, IsActive = true, CreatedDate = DateTime.Now }
                };
                context.CarrierConfigurations.AddRange(carrierConfigurations);

                // Save changes
                context.SaveChanges();
            }
        }
    }
}
