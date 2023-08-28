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
            // initialize total discounted amount
            var totalPriceWithAppliedDiscount = 0.0m;

            // for each discount request in discount requests
            foreach (var request in discountRequests)
            {
                // quantity ordered for each watch
                int quantityOrdered = request.QuantityOrdered;
                // unit price of the watch
                decimal unitPrice = request.UnitPrice;

                // Check if discount is available and can be applied
                if (request.DiscountAmount.HasValue && request.DiscountEligibleQuantity.HasValue)
                {
                    // get the discount quantity and discountAmount
                    int discountEligbleQuantity = request.DiscountEligibleQuantity.Value;
                    decimal discountAmount = request.DiscountAmount.Value;

                    // Calculate how many times the discount applies
                    int numDiscounts = quantityOrdered / discountEligbleQuantity;

                    // the remaining watches that don't qualify for the discount
                    int remainingItems = quantityOrdered % discountEligbleQuantity;

                    // Here we use number of discounts for watch * discount amount
                    // if there is any reamaining watch of same type we dont' take discount advantage just apply unit price
                    // for example: if watchid = "002" has discount 2 for 100 and unit price is 150
                    // if we request 3 of these watches, we would apply 100 (2 * 100) + (1 * 150)
                    totalPriceWithAppliedDiscount += (numDiscounts * discountAmount) + (remainingItems * unitPrice);
                }
                else
                {
                    // No discount, just multiply the unit price by the quantity
                    totalPriceWithAppliedDiscount += quantityOrdered * unitPrice;
                }
            }

            return totalPriceWithAppliedDiscount;
        }
        #endregion
    }
}