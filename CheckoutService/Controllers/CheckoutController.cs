
#region References
using ECommerceApp.CatalogueService.Interfaces;
using ECommerceApp.CheckoutService.Dtos;
using ECommerceApp.DiscountService.Dtos;
using ECommerceApp.DiscountService.Interfaces;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace ECommerceApp.CheckoutService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        #region Fields
        private readonly IWatchCatalogueService watchCatalogueService;
        private readonly IDiscountSvc discountSvc;
        private readonly ILogger<CheckoutController> logger;
        #endregion

        #region Methods
        public CheckoutController(IWatchCatalogueService watchCatalogueService, IDiscountSvc discountSvc, ILogger<CheckoutController> logger)
        {
            this.watchCatalogueService = watchCatalogueService;
            this.discountSvc = discountSvc;
            this.logger = logger;
        }

        /// <summary>Method handles an HTTP POST request for checkout</summary>
        /// <param name="watchIds">List of watch ids</param>
        /// <returns>Price of the watches for checkout </returns>
        [HttpPost]
        public IActionResult Checkout([FromBody] List<string> watchIds)
        {
            if (watchIds == null || watchIds.Count == 0)
            {
                logger.LogWarning("The watchIds list cannot be null or empty.");
                return BadRequest("The watchIds list cannot be null or empty.");
            }

            // Count each watch ID passed in the request
            var watchIdCounts = watchIds.GroupBy(id => id)
                                        .ToDictionary(group => group.Key, group => group.Count());


            // Fetch unique watch types based on IDs provided in the request
            var watchTypes = watchCatalogueService.GetWatchesByIds(watchIds.Distinct().ToList());

            // Check if all watches exist in the catalogue, there us a watch that is not part of watch repository
            if (watchTypes.Count != watchIdCounts.Keys.Count)
            {
                logger.LogWarning("One or more watches were not found.");
                return NotFound("One or more watches were not found.");
            }

            // Create DiscountRequests based on the watch types and their counts
            var discountRequests = watchTypes.Select(w => new DiscountRequestDto
            {
                UnitPrice = w.UnitPrice,
                QuantityOrdered = watchIdCounts[w.WatchId],
                DiscountAmount = w.SpecialDiscount?.Amount,
                DiscountEligibleQuantity = w.SpecialDiscount?.Quantity
            }).ToList();

            var totalPrice = discountSvc.CalculateTotalDiscountedPrice(discountRequests);
            logger.LogInformation($"Total price {totalPrice} for Watch Ids: {string.Join(",", watchIds)}");

            var response = new CheckoutResponseDto { Price = totalPrice };
            return Ok(response);
        }
        #endregion

    }
}