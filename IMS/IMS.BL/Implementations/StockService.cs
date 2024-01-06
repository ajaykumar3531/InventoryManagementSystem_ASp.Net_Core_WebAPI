using IMS.BL.Contracts;
using IMS.DL.Contracts;
using IMS.DL.Entities;
using IMS.MODELS.StockDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL.Implementations
{
    public class StockService : IStockService
    {
        private readonly IDataAccess<Stock> _stockService;
        private readonly IDataAccess<Product> _productService;

        public StockService(IDataAccess<Stock> stockService, IDataAccess<Product> productService)
        {
            _stockService = stockService;
            _productService = productService;
        }

        public async Task<StockDTO> AddStock(StockDTO stockDTO)
        {
            try
            {
                var data = await _productService.GetById(stockDTO.ProductId.Value);
                if (data != null)
                {
                    Stock stock = MapTOEntity(stockDTO);
                    _stockService.Add(stock);
                    if (await _stockService.SaveChangesAsync())
                    {
                        return MapTODTO(stock);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in AddStock: {ex.Message}");
                return null;
            }
        }

        public async Task<StockDTO> DeleteStock(int id)
        {
            try
            {
                var data = await _stockService.GetById(id);
                if (data != null)
                {
                    _stockService.Delete(data);
                    if (await _stockService.SaveChangesAsync())
                    {
                        return MapTODTO(data);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in DeleteStock: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Stock>> GetAll()
        {
            try
            {
                var data = await _stockService.GetAll();
                return data;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in GetAllStocks: {ex.Message}");
                return null;
            }
        }

        public async Task<StockUpdateDTO> GetById(int id)
        {
            try
            {
                var data = await _stockService.GetById(id);
                if (data != null)
                {
                    return MapTOUpdateStockDTO(data);
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in GetStockById: {ex.Message}");
                return null;
            }
        }

        public async Task<StockUpdateDTO> UpdateStock(int id, StockUpdateDTO stockUpdateDTO)
        {
            try
            {
                var existingStock = await _stockService.GetById(id);
                var data = await _productService.GetById(stockUpdateDTO.ProductId.Value);
                if (existingStock != null && data != null)
                {
                    existingStock.Quantity = stockUpdateDTO.Quantity;
                    _stockService.Update(existingStock);
                    if (await _stockService.SaveChangesAsync())
                    {
                        return MapTOUpdateStockDTO(existingStock);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in UpdateStock: {ex.Message}");
                return null;
            }
        }

        private Stock MapTOEntity(StockDTO stockDTO)
        {
            return new Stock
            {

                CreatedDate = stockDTO.CreatedDate,
                LastModifiedDate = stockDTO.LastModifiedDate,
                ProductId = stockDTO.ProductId,
                Quantity = stockDTO.Quantity
            };
        }

        private StockDTO MapTODTO(Stock stock)
        {
            return new StockDTO
            {

                CreatedDate = stock.CreatedDate,
                LastModifiedDate = stock.LastModifiedDate,
                ProductId = stock.ProductId,
                Quantity = stock.Quantity
            };
        }

        private StockUpdateDTO MapTOUpdateStockDTO(Stock updateStockDTO)
        {
            return new StockUpdateDTO
            {
                CreatedDate = updateStockDTO.CreatedDate,
                LastModifiedDate = updateStockDTO.LastModifiedDate,
                ProductId = updateStockDTO.ProductId,
                Quantity = updateStockDTO.Quantity
            };
        }
    }
}
