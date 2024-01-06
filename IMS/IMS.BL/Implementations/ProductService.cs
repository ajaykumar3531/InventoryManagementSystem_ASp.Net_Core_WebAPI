using IMS.BL.Contracts;
using IMS.DL.Contracts;
using IMS.DL.Entities;
using IMS.MODELS.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IDataAccess<Product> _productRepo;

        public ProductService(IDataAccess<Product> product)
        {
            _productRepo = product;
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            try
            {
                var productData = await _productRepo.GetAll();
                var productDTOList = productData.Select(MapToProductDTO).ToList();
                return productDTOList;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in GetProductsAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO dto)
        {
            try
            {
                Product product = MapToEntity(dto);
                _productRepo.Add(product);
                if (await _productRepo.SaveChangesAsync())
                {
                    return MapToProductDTO(product);
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in AddProductAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<ProductUpdateDTO> UpdateProductAsync(int id, ProductUpdateDTO dto)
        {
            try
            {
                var existingProduct = await _productRepo.GetById(id);

                if (existingProduct != null)
                {
                    existingProduct.ProductName = dto.ProductName;
                    existingProduct.ProductDetails = dto.ProductDetails;
                    existingProduct.CategoryName = dto.CategoryName;
                    existingProduct.CreatedDate = dto.CreatedDate;
                    existingProduct.Price = dto.Price;
                    _productRepo.Update(existingProduct);
                    if (await _productRepo.SaveChangesAsync())
                    {
                        return MapTOProductUpdateDTO(existingProduct);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in UpdateProductAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<ProductDTO> DeleteProductAsync(int id)
        {
            try
            {
                var data = await _productRepo.GetById(id);
                if (data != null)
                {
                    _productRepo.Delete(data);
                    if (await _productRepo.SaveChangesAsync())
                    {
                        return MapToProductDTO(data);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in DeleteProductAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<ProductUpdateDTO> GetProductById(int id)
        {
            try
            {
                var data = await _productRepo.GetById(id);
                if (data != null)
                {
                    return MapTOProductUpdateDTO(data);
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                Console.WriteLine($"An error occurred in GetProductById: {ex.Message}");
                return null;
            }
        }

        private ProductDTO MapToProductDTO(Product product)
        {
            return new ProductDTO
            {
                Price = product.Price,
                ProductDetails = product.ProductDetails,
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                CategoryName = product.CategoryName,
                CreatedDate = product.CreatedDate
            };
        }

        private ProductUpdateDTO MapTOProductUpdateDTO(Product dto)
        {
            return new ProductUpdateDTO
            {
                ProductName = dto.ProductName,
                ProductDetails = dto.ProductDetails,
                CreatedDate = dto.CreatedDate,
                CategoryName = dto.CategoryName,
                Price = dto.Price
            };
        }

        private Product MapToEntity(ProductDTO product)
        {
            return new Product
            {
                Price = product.Price,
                ProductDetails = product.ProductDetails,
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                CategoryName = product.CategoryName,
                CreatedDate = product.CreatedDate,
            };
        }
    }
}
