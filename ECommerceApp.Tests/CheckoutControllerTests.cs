
using ECommerceApp.CatalogueService.Interfaces;
using ECommerceApp.CatalogueService.Models;
using ECommerceApp.CheckoutService.Controllers;
using ECommerceApp.CheckoutService.Dtos;
using ECommerceApp.DiscountService.Dtos;
using ECommerceApp.DiscountService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace ECommerceApp.Tests
{
    public class CheckoutControllerTests
    {
        private CheckoutController controller;
        private Mock<IWatchCatalogueService> catalogueServiceMock;
        private Mock<IDiscountSvc> discountServiceMock;
        private Mock<ILogger<CheckoutController>> checkoutLoggerMock;

        [SetUp]
        public void Setup()
        {
            catalogueServiceMock = new Mock<IWatchCatalogueService>();
            discountServiceMock = new Mock<IDiscountSvc>();
            checkoutLoggerMock = new Mock<ILogger<CheckoutController>>();
            controller = new CheckoutController(catalogueServiceMock.Object, discountServiceMock.Object, checkoutLoggerMock.Object);
        }

        [Test]
        public void Checkout_ValidRequest__ReturnsPrice()
        {
            // Arrange
            var watchIds = new List<string> { "001", "002" };
            var watchList = new List<Watch>
            {
                new Watch { WatchId = "001", Name = "Rolex", UnitPrice = 100 },
                new Watch { WatchId = "002", Name = "Michael Kors", UnitPrice = 80 }
            };
            var expectedTotalPrice = 180;

            catalogueServiceMock.Setup(s => s.GetWatchesByIds(It.IsAny<List<string>>()))
                                 .Returns(watchList);

            discountServiceMock.Setup(s => s.CalculateTotalDiscountedPrice(It.IsAny<List<DiscountRequestDto>>()))
                                .Returns(expectedTotalPrice);

            // Act
            var result = controller.Checkout(watchIds) as OkObjectResult;

            if (result?.Value is CheckoutResponseDto checkoutResponse)
            {
                // Assert
                Assert.That(checkoutResponse.Price, Is.EqualTo(expectedTotalPrice));
            }
            else
            {
                Assert.Fail("Result is not of expected type.");
            }
        }

        [Test]
        public void Checkout_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange & Act
            var result = controller.Checkout(null);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Checkout_UnknownWatchId_ReturnsNotFound()
        {
            // Arrange
            var watchIds = new List<string> { "005" }; // Unknown Watch ID

            catalogueServiceMock.Setup(s => s.GetWatchesByIds(It.IsAny<List<string>>()))
                                 .Returns(new List<Watch>());

            // Act
            var result = controller.Checkout(watchIds);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

    }
}