using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.MODELS.ProductDTO
{
    public class ProductUpdateDTO
    {
        public string? ProductName { get; set; }

        public string? CategoryName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal? Price { get; set; }

        public string? ProductDetails { get; set; }
    }
}
