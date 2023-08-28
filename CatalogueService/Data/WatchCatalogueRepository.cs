#region References
using ECommerceApp.CatalogueService.Data;
using ECommerceApp.CatalogueService.Interfaces;
using ECommerceApp.CatalogueService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
#endregion

namespace ECommerceApp.CatalogueService.Data
{
    public class WatchCatalogueRepository : IWatchCatalogueRepository
    {
        #region Fields
        private readonly CatalogueDbContext context;
        private readonly ILogger<WatchCatalogueRepository> logger;
        #endregion

        public WatchCatalogueRepository(CatalogueDbContext context, ILogger<WatchCatalogueRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public Watch? GetWatchById(string watchId)
        {
            if (string.IsNullOrEmpty(watchId))
            {
                throw new ArgumentException("Watch ID cannot be null or empty", nameof(watchId));
            }

            return context.Watches.FirstOrDefault(w => w.WatchId == watchId);
        }

        /// <inheritdoc/>
        public List<Watch> GetWatchesByIds(List<string> watchIds)
        {
            logger.LogInformation($"Get watches for {string.Join(",", watchIds)}");

            if (watchIds == null || !watchIds.Any())
            {
                logger.LogError("The list of watch IDs cannot be null or empty.");
                throw new ArgumentException("The list of watch IDs cannot be null or empty.");
            }

            return context.Watches.Include(w => w.SpecialDiscount).Where(w => watchIds.Contains(w.WatchId, StringComparer.OrdinalIgnoreCase)).ToList();
        }
    }
}