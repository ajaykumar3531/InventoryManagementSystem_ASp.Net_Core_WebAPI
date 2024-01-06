using IMS.DL.Entities;
using IMS.MODELS.StockDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL.Contracts
{
    public interface IStockService
    {
        Task<List<Stock>> GetAll();
        Task<StockUpdateDTO> GetById(int id);
        Task<StockDTO> DeleteStock(int id);

        Task<StockDTO> AddStock(StockDTO stock);

        Task<StockUpdateDTO> UpdateStock(int id, StockUpdateDTO updateStockDto);
    }
}
