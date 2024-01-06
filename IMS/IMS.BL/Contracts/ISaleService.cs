using IMS.MODELS.SaleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL.Contracts
{
    public interface ISaleService
    {
        Task<List<SaleDTO>> GetAll();
        Task<SaleDTO> AddSale(SaleDTO saleDTO);
        Task<SaleDTO> DeleteSale(int id);
        Task<SaleUpdateDTO> GetById(int id);
        Task<SaleUpdateDTO> UpdateSale(int id, SaleUpdateDTO saleDTO);
    }
}
