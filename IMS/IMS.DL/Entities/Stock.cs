using System;
using System.Collections.Generic;

namespace IMS.DL.Entities;

public partial class Stock
{
    public int StockId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual Product? Product { get; set; }
}
