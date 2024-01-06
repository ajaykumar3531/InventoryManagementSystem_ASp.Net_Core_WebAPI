using IMS.BL.Contracts;
using IMS.DL.Contracts;
using IMS.DL.Entities;
using IMS.MODELS.SaleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly IDataAccess<Sale> _saleService;
        private readonly IDataAccess<Product> _productService;

        public SaleService(IDataAccess<Sale> saleService, IDataAccess<Product> productService)
        {
            _saleService = saleService;
            _productService = productService;
        }

        public async Task<SaleDTO> AddSale(SaleDTO saleDTO)
        {
            try
            {
                var data = await _productService.GetById(saleDTO.ProductId.Value);
                if (data != null)
                {
                    Sale sale = MapTOEntity(saleDTO);
                    _saleService.Add(sale);
                    if (await _saleService.SaveChangesAsync())
                    {
                        return MapTODTO(sale);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in AddSale: {ex.Message}");
                return null;
            }
        }

        public async Task<SaleDTO> DeleteSale(int id)
        {
            try
            {
                var data = await _saleService.GetById(id);
                if (data != null)
                {
                    _saleService.Delete(data);
                    if (await _saleService.SaveChangesAsync())
                    {
                        return MapTODTO(data);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in DeleteSale: {ex.Message}");
                return null;
            }
        }

        public async Task<List<SaleDTO>> GetAll()
        {
            try
            {
                var data = await _saleService.GetAll();
                return data.Select(MapTODTO).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in GetAll: {ex.Message}");
                return new List<SaleDTO>();
            }
        }

        public async Task<SaleUpdateDTO> GetById(int id)
        {
            try
            {
                var data = await _saleService.GetById(id);
                if (data != null)
                {
                    return MapTOUpdate(data);
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in GetById: {ex.Message}");
                return null;
            }
        }

        public async Task<SaleUpdateDTO> UpdateSale(int id, SaleUpdateDTO saleDTO)
        {
            try
            {
                var existingSale = await _saleService.GetById(id);
                var data = await _productService.GetById(saleDTO.ProductId.Value);
                if (existingSale != null && data != null)
                {
                    existingSale.SaleDate = saleDTO.SaleDate;
                    existingSale.MobileNo = saleDTO.MobileNo;
                    existingSale.InvoiceNo = saleDTO.InvoiceNo;
                    existingSale.CustomerName = saleDTO.CustomerName;
                    existingSale.ProductId = saleDTO.ProductId;
                    existingSale.TotalAmount = saleDTO.TotalAmount;
                    existingSale.Quantity = saleDTO.Quantity;
                    _saleService.Update(existingSale);
                    if (await _saleService.SaveChangesAsync())
                    {
                        return MapTOUpdate(existingSale);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in UpdateSale: {ex.Message}");
                return null;
            }
        }

        private Sale MapTOEntity(SaleDTO saleDTO)
        {
            return new Sale
            {
                SaleDate = saleDTO.SaleDate,
                SaleId = saleDTO.SaleId,
                CustomerName = saleDTO.CustomerName,
                InvoiceNo = saleDTO.InvoiceNo,
                MobileNo = saleDTO.MobileNo,
                ProductId = saleDTO.ProductId,
                Quantity = saleDTO.Quantity,
                TotalAmount = saleDTO.TotalAmount
            };
        }

        private SaleDTO MapTODTO(Sale sale)
        {
            return new SaleDTO
            {
                SaleDate = sale.SaleDate,
                SaleId = sale.SaleId,
                CustomerName = sale.CustomerName,
                InvoiceNo = sale.InvoiceNo,
                MobileNo = sale.MobileNo,
                ProductId = sale.ProductId,
                Quantity = sale.Quantity,
                TotalAmount = sale.TotalAmount
            };
        }

        private SaleUpdateDTO MapTOUpdate(Sale saleUpdateDTO)
        {
            return new SaleUpdateDTO
            {
                SaleDate = saleUpdateDTO.SaleDate,
                CustomerName = saleUpdateDTO.CustomerName,
                InvoiceNo = saleUpdateDTO.InvoiceNo,
                MobileNo = saleUpdateDTO.MobileNo,
                ProductId = saleUpdateDTO.ProductId,
                Quantity = saleUpdateDTO.Quantity,
                TotalAmount = saleUpdateDTO.TotalAmount
            };
        }
    }
}
