#region Refernces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace ECommerceApp.CatalogueService.Models
{
    //// <summary> Data Model for Watch. </summary>
    public class Watch
    {
        #region Properties
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WatchDbId { get; set; }

        [Required]
        [StringLength(50)]
        public required string WatchId { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public Discount? SpecialDiscount { get; set; } // using another model to represent discount
        #endregion
    }
}
