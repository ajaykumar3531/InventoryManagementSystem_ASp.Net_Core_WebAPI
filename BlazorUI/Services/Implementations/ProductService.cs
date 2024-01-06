using BlazorUI.Services.Contracts;
using IMS.MODELS.ProductDTO;
using System.Net.Http.Json;

namespace BlazorUI.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddProductAsync(ProductDTO productDto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Product", productDto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> DeleteProductAsync(int id)
        {

            try
            {
                await _httpClient.DeleteAsync($"api/Product/{id}");
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting department: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error deleting department: {ex.Message}");
                throw;
            }
        }

        public async Task<ProductUpdateDTO> GetProductById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ProductUpdateDTO>($"/api/Proudct/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {

                return null;
            }
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            try
            {
                var data = await _httpClient.GetFromJsonAsync<List<ProductDTO>>("api/Product");
                if (data == null)
                {
                    return null;
                }
                else
                {
                    return data;
                }
                
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<ProductUpdateDTO> UpdateProductAsync(int productId, ProductUpdateDTO updateProduct)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<ProductUpdateDTO>($"api/Product/{productId}", updateProduct);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ProductUpdateDTO>();
                }
                else
                {
              
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                
                Console.WriteLine($"HTTP request exception: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return null;
            }
        }

    }
}
