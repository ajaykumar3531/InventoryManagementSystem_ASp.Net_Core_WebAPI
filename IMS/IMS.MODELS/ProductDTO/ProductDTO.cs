using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.MODELS.ProductDTO
{
   
    public class ProductDTO
    {
        [Required(ErrorMessage = "ProductId is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "CategoryName is required")]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "CreatedDate is required")]
        public DateTime? CreatedDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "ProductDetails is required")]
        public string? ProductDetails { get; set; }
    }

}
