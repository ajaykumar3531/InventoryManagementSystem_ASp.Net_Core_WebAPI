using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.MODELS.PurchaseDTO
{
    public class PurchaseUpdateDTO
    {
        public DateTime? PurchaseDate { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? SupplierName { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public string? InvoiceNo { get; set; }
    }
}
