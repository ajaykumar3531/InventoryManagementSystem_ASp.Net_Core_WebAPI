using IMS.MODELS.PurchaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL.Contracts
{
    public interface IPurchaseService
    {
        Task<List<PurchaseDTO>> GetAll();
        Task<PurchaseDTO> AddPurchase(PurchaseDTO purchaseDTO);
        Task<PurchaseUpdateDTO> UpdatePurchase(int id, PurchaseUpdateDTO purchaseDTO);
        Task<PurchaseDTO> DeletePurchase(int id);
        Task<PurchaseUpdateDTO> GetPurchaseById(int id);
    }
}
