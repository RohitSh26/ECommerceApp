#region References
using ECommerceApp.CatalogueService.Data;
using ECommerceApp.CatalogueService.Interfaces;
using ECommerceApp.CatalogueService.Models;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace ECommerceApp.CatalogueService.Data
{
    public class CatalogueDataSeeder : ICatalogueDataSeeder
    {
        #region IDataSeeder Interface Methods

        /// <inheritdoc />
        public void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                // Get CatalogueDbContext instance from service provider
                var context = serviceScope.ServiceProvider.GetRequiredService<CatalogueDbContext>();
                if (!context.Watches.Any())
                {
                    // Adding data to populate initial database
                    // used watch catalogue from the challenge for population data
                    var discount1 = new Discount { DiscountDbId = 1, Quantity = 3, Amount = 200 };
                    var discount2 = new Discount { DiscountDbId = 2, Quantity = 2, Amount = 120 };

                    var watch1 = new Watch { WatchDbId = 1, WatchId = "001", Name = "Rolex", UnitPrice = 100, SpecialDiscount = discount1 };
                    var watch2 = new Watch { WatchDbId = 2, WatchId = "002", Name = "Michael Kors", UnitPrice = 80, SpecialDiscount = discount2 };
                    var watch3 = new Watch { WatchDbId = 3, WatchId = "003", Name = "Swatch", UnitPrice = 50 };
                    var watch4 = new Watch { WatchDbId = 4, WatchId = "004", Name = "Casio", UnitPrice = 30 };

                    context.AddRange(discount1, discount2);
                    context.AddRange(watch1, watch2, watch3, watch4);
                }
                // Save changes to the database
                context.SaveChanges();
            }
        }
        #endregion
    }
}