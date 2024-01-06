using System;
using System.ComponentModel.DataAnnotations;

public class PurchaseDTO
{
    public int PurchaseId { get; set; }

    [Display(Name = "Purchase Date")]
    [Required(ErrorMessage = "Purchase Date is required.")]
    public DateTime? PurchaseDate { get; set; }

    [Required(ErrorMessage = "Product ID is required.")]
    public int? ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]

    public int? Quantity { get; set; }

    [Display(Name = "Supplier Name")]
    [Required(ErrorMessage = "Supplier Name is required.")]
    public string? SupplierName { get; set; }

    [Display(Name = "Invoice Amount")]
    [Required(ErrorMessage = "Invoice Amount is required.")]
   
    public decimal? InvoiceAmount { get; set; }

    [Display(Name = "Invoice Number")]
    [Required(ErrorMessage = "Invoice Number is required.")]
    public string? InvoiceNo { get; set; }
}
