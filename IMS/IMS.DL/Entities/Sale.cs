using System;
using System.Collections.Generic;

namespace IMS.DL.Entities;

public partial class Sale
{
    public int SaleId { get; set; }

    public string? InvoiceNo { get; set; }

    public string? CustomerName { get; set; }

    public string? MobileNo { get; set; }

    public DateTime? SaleDate { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Product? Product { get; set; }
}
