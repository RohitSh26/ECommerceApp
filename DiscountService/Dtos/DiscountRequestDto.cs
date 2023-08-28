namespace ECommerceApp.DiscountService.Dtos
{
    /// <summary> Represents the request for calculating discounts. </summary>
    public class DiscountRequestDto
    {
        #region Properties
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? DiscountQuantity { get; set; }
        #endregion
    }
}