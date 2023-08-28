#region References
using ECommerceApp.DiscountService.Dtos;
#endregion

namespace ECommerceApp.DiscountService.Interfaces
{
    /// <summary> Interface for calculating discounted price. </summary>
    public interface IDiscountSvc
    {
        #region Methods
        /// <summary>Method to calculate the discounted amount based on the discount request
        /// </summary>
        /// <param name="discountRequest">The discount request.</param>
        /// <returns>The discounted amount.</returns>
        decimal CalculateDiscountedPrice(DiscountRequestDto discountRequest);

        /// <summary>Method to calculate the total discounted amount for a list of items. </summary>
        /// <param name="discountRequests">Collection of discount requests.</param>
        /// <returns>The total discounted amount.</returns>
        decimal CalculateTotalDiscountedPrice(List<DiscountRequestDto> discountRequests);
        #endregion
    }
}
