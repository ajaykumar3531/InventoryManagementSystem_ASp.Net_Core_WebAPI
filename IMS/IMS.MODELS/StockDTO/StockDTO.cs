using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.MODELS.StockDTO
{
    public class StockDTO
    {
        [Display(Name = "Product ID")]
        [Required(ErrorMessage = "Product ID is required.")]
        public int? ProductId { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int? Quantity { get; set; }

        [Display(Name = "Created Date")]
        [Required(ErrorMessage = "Created Date is required.")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Modified Date")]
        [Required(ErrorMessage = "Last Modified Date is required.")]
        public DateTime? LastModifiedDate { get; set; }
    }
}
