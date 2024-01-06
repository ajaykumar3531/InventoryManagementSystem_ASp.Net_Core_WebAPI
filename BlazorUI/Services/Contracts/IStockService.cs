using IMS.DL.Entities;
using IMS.MODELS.ProductDTO;
using IMS.MODELS.StockDTO;

namespace BlazorUI.Services.Contracts
{
    public interface IStockService
    {
        Task<List<Stock>> GetStockAsync();
        Task<bool> AddStockAsync(StockDTO dto);
        Task<StockUpdateDTO> UpdateStockAsync(int id, StockUpdateDTO dto);
        Task<bool> DeleteStockAsync(int id);
        Task<StockUpdateDTO> GetStockById(int id);
    }
}

