
#region References
using ECommerceApp.CatalogueService.Interfaces;
using ECommerceApp.CheckoutService.Dtos;
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

            // TODO - Implement later
            return Ok(new CheckoutResponseDto() { Price = 0.0m });
        }
        #endregion

    }
}