#region References
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace ECommerceApp.CatalogueService.Models
{
    /// <summary> Data Model for Discount. </summary>
    public class Discount
    {
        #region Properties
        [Key]
        public int DiscountDbId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        #endregion
    }
}
