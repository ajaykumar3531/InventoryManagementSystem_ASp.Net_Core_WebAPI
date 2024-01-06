using IMS.BL.Contracts;
using IMS.DL.Contracts;
using IMS.DL.Entities;
using IMS.MODELS.PurchaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IDataAccess<Purchase> _purchaseRepo;
        private readonly IDataAccess<Product> _productRepo;

        public PurchaseService(IDataAccess<Purchase> purchaseRepo, IDataAccess<Product> productRepo)
        {
            _purchaseRepo = purchaseRepo;
            _productRepo = productRepo;
        }

        public async Task<PurchaseDTO> DeletePurchase(int id)
        {
            try
            {
                var data = await _purchaseRepo.GetById(id);
                if (data != null)
                {
                    _purchaseRepo.Delete(data);
                    if (await _purchaseRepo.SaveChangesAsync())
                    {
                        return MapTODTO(data);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in DeletePurchase: {ex.Message}");
                return null;
            }
        }

        public async Task<List<PurchaseDTO>> GetAll()
        {
            try
            {
                var data = await _purchaseRepo.GetAll();
                return data.Select(MapTODTO).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in GetAll: {ex.Message}");
                return new List<PurchaseDTO>();
            }
        }

        public async Task<PurchaseUpdateDTO> GetPurchaseById(int id)
        {
            try
            {
                var data = await _purchaseRepo.GetById(id);
                return MapTOPurchaseUpdateDTO(data); 
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in GetPurchaseById: {ex.Message}");
                return null;
            }
        }

        public async Task<PurchaseUpdateDTO> UpdatePurchase(int id, PurchaseUpdateDTO purchaseDTO)
        {
            try
            {
                var productData = await _productRepo.GetById(purchaseDTO.ProductId.Value);
                var existingPurchase = await _purchaseRepo.GetById(id);
                if (existingPurchase != null && productData != null)
                {
                    existingPurchase.PurchaseDate = purchaseDTO.PurchaseDate;
                    existingPurchase.ProductId = purchaseDTO.ProductId;
                    existingPurchase.InvoiceNo = purchaseDTO.InvoiceNo;
                    existingPurchase.InvoiceAmount = purchaseDTO.InvoiceAmount;
                    existingPurchase.SupplierName = purchaseDTO.SupplierName;
                    existingPurchase.Quantity = purchaseDTO.Quantity;
                    _purchaseRepo.Update(existingPurchase);
                    if (await _purchaseRepo.SaveChangesAsync())
                    {
                        return MapTOPurchaseUpdateDTO(existingPurchase);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in UpdatePurchase: {ex.Message}");
                return null;
            }
        }

        public async Task<PurchaseDTO> AddPurchase(PurchaseDTO purchaseDTO)
        {
            try
            {
                var data = await _productRepo.GetById(purchaseDTO.ProductId.Value);
                if (data != null)
                {
                    Purchase purchase = MapToEntity(purchaseDTO);
                    _purchaseRepo.Add(purchase);
                    if (await _purchaseRepo.SaveChangesAsync())
                    {
                        return MapTODTO(purchase);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in AddPurchase: {ex.Message}");
                return null;
            }
        }

        private Purchase MapToEntity(PurchaseDTO purchaseDTO)
        {
            return new Purchase
            {
                PurchaseId = purchaseDTO.PurchaseId,
                PurchaseDate = purchaseDTO.PurchaseDate,
                ProductId = purchaseDTO.ProductId,
                InvoiceAmount = purchaseDTO.InvoiceAmount,
                InvoiceNo = purchaseDTO.InvoiceNo,
                Quantity = purchaseDTO.Quantity,
                SupplierName = purchaseDTO.SupplierName,
            };
        }

        private PurchaseDTO MapTODTO(Purchase purchase)
        {
            return new PurchaseDTO
            {
                PurchaseId = purchase.PurchaseId,
                PurchaseDate = purchase.PurchaseDate,
                ProductId = purchase.ProductId,
                InvoiceAmount = purchase.InvoiceAmount,
                InvoiceNo = purchase.InvoiceNo,
                Quantity = purchase.Quantity,
                SupplierName = purchase.SupplierName,
            };
        }

        private PurchaseUpdateDTO MapTOPurchaseUpdateDTO(Purchase purchase)
        {
            return new PurchaseUpdateDTO
            {
                ProductId = purchase.ProductId,
                PurchaseDate = purchase.PurchaseDate,
                InvoiceNo = purchase.InvoiceNo,
                InvoiceAmount = purchase.InvoiceAmount,
                Quantity = purchase.Quantity,
                SupplierName = purchase.SupplierName,
            };
        }
    }
}
