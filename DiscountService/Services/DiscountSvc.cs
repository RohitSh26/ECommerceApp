#region References
using ECommerceApp.DiscountService.Dtos;
using ECommerceApp.DiscountService.Interfaces;
using Microsoft.Extensions.Logging;
#endregion

namespace ECommerceApp.DiscountService.Services
{
    /// <summary>The DiscountCalculator class. </summary>
    public class DiscountSvc : IDiscountSvc
    {
        #region Fields
        private readonly ILogger<DiscountSvc> logger;
        #endregion

        #region Methods

        public DiscountSvc(ILogger<DiscountSvc> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc />
        public decimal CalculateDiscountedPrice(DiscountRequestDto discountRequest)
        {
            // TODO - Implement later
            return 0;
        }

        /// <inheritdoc />
        public decimal CalculateTotalDiscountedPrice(List<DiscountRequestDto> discountRequests)
        {
            // TODO - Implement later
            return 0;
        }
        #endregion
    }
}