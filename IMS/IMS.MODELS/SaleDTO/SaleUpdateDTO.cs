using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.MODELS.SaleDTO
{
    public class SaleUpdateDTO
    {
        public string? InvoiceNo { get; set; }

        public string? CustomerName { get; set; }

        public string? MobileNo { get; set; }

        public DateTime? SaleDate { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}
