#region References
using ECommerceApp.CatalogueService.Models;
#endregion

namespace ECommerceApp.CatalogueService.Interfaces
{
    public interface IWatchCatalogueService
    {
        #region Methods
        /// <summary>Retrieves Watch by watch id. </summary>
        /// <param name="watchId">Watch Identifier</param>
        /// <returns>he watch with the specified ID.</returns>
        Watch? GetWatchById(string watchId);

        /// <summary> Retrieves multiple watches based on their IDs </summary>
        /// <param name="watchIds">Collection of watch id</param>
        /// <returns>Collection of Watch for specified watchids </returns>
        List<Watch> GetWatchesByIds(List<string> watchIds);

        #endregion
    }
}
