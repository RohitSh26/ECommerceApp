
#region References
using ECommerceApp.CatalogueService.Interfaces;
using ECommerceApp.CatalogueService.Models;
#endregion

namespace ECommerceApp.CatalogueService.Services
{
    public class WatchCatalogueService : IWatchCatalogueService
    {
        #region Fields
        private readonly IWatchCatalogueRepository repository;
        #endregion

        #region Methods
        public WatchCatalogueService(IWatchCatalogueRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public Watch? GetWatchById(string watchId)
        {
            return repository.GetWatchById(watchId);
        }

        /// <inheritdoc/>
        public List<Watch> GetWatchesByIds(List<string> watchIds)
        {
            return repository.GetWatchesByIds(watchIds);
        }
        #endregion
    }
}