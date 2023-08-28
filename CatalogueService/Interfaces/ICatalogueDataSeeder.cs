namespace ECommerceApp.CatalogueService.Interfaces
{
    public interface ICatalogueDataSeeder
    {
        #region Methods
        /// <summary>Seeds the initial data into the database </summary>
        /// <param name="serviceProvider">The service provider to get required services </param>
        void SeedData(IServiceProvider serviceProvider);
        #endregion
    }
}