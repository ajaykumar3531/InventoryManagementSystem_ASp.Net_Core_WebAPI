using System;
using System.Collections.Generic;

namespace IMS.DL.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? CategoryName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public decimal? Price { get; set; }

    public string? ProductDetails { get; set; }

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();

    public virtual ICollection<Stock> Stocks { get; } = new List<Stock>();
}
