using IMS.MODELS.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL.Contracts
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> AddProductAsync(ProductDTO dto);
        Task<ProductUpdateDTO> UpdateProductAsync(int id,ProductUpdateDTO dto);
        Task<ProductDTO> DeleteProductAsync(int id);
        Task<ProductUpdateDTO> GetProductById(int id);
    }
}
