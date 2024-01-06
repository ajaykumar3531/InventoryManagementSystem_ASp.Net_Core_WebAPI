using IMS.MODELS.PurchaseDTO;
using IMS.MODELS.SaleDTO;

namespace BlazorUI.Services.Contracts
{
    public interface ISaleService
    {
        Task<List<SaleDTO>> GetSaleAsync();
        Task<bool> AddPurchaseAsync(SaleDTO dto);
        Task<SaleUpdateDTO> UpdatePurchaseAsync(int id, SaleUpdateDTO dto);
        Task<bool> DeletePurchaseAsync(int id);
        Task<SaleUpdateDTO> GetPurchaseById(int id);
    }
}
