using IMS.MODELS.ProductDTO;

namespace BlazorUI.Services.Contracts
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProductsAsync();
        Task<bool> AddProductAsync(ProductDTO dto);
        Task<ProductUpdateDTO> UpdateProductAsync(int id, ProductUpdateDTO dto);
        Task<bool> DeleteProductAsync(int id);
        Task<ProductUpdateDTO> GetProductById(int id);
    }
}
