using System;
using System.Collections.Generic;

namespace IMS.DL.Entities;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public string? SupplierName { get; set; }

    public decimal? InvoiceAmount { get; set; }

    public string? InvoiceNo { get; set; }

    public virtual Product? Product { get; set; }
}
