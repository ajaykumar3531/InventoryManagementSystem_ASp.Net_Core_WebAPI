using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.MODELS.SaleDTO
{
    public class SaleDTO
    {
        public int SaleId { get; set; }

        [Display(Name = "Invoice Number")]
        [Required(ErrorMessage = "Invoice Number is required.")]
        public string? InvoiceNo { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer Name is required.")]
        public string? CustomerName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        public string? MobileNo { get; set; }

        [Display(Name = "Sale Date")]
        [Required(ErrorMessage = "Sale Date is required.")]
        public DateTime? SaleDate { get; set; }

        [Display(Name = "Product ID")]
        [Required(ErrorMessage = "Product ID is required.")]
        public int? ProductId { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int? Quantity { get; set; }

        [Display(Name = "Total Amount")]
        [Required(ErrorMessage = "Total Amount is required.")]
        public decimal? TotalAmount { get; set; }
    }
}
