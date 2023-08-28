#region References
using ECommerceApp.CatalogueService.Models;
using Microsoft.EntityFrameworkCore;
#endregion

namespace ECommerceApp.CatalogueService.Data
{
    public class CatalogueDbContext : DbContext
    {
        #region Properties
        public DbSet<Watch> Watches { get; set; }
        #endregion

        #region Methods

        public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("WatchCatalogueDB");
        }
        #endregion
    }
}