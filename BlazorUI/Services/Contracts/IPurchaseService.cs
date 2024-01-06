using IMS.MODELS.ProductDTO;
using IMS.MODELS.PurchaseDTO;

namespace BlazorUI.Services.Contracts
{
    public interface IPurchaseService
    {
        Task<List<PurchaseDTO>> GetPurchaseAsync();
        Task<bool> AddPurchaseAsync(PurchaseDTO dto);
        Task<PurchaseUpdateDTO> UpdatePurchaseAsync(int id, PurchaseUpdateDTO dto);
        Task<bool> DeletePurchaseAsync(int id);
        Task<PurchaseUpdateDTO> GetPurchaseById(int id);
    }
}
