using BlazorUI.Services.Contracts;
using IMS.MODELS.PurchaseDTO;
using System.Net.Http.Json;

namespace BlazorUI.Services.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        private readonly HttpClient _httpClient;

        public PurchaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddPurchaseAsync(PurchaseDTO purchaseDto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Purchase", purchaseDto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding purchase: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeletePurchaseAsync(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Purchase/{id}");
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting purchase: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error deleting purchase: {ex.Message}");
                throw;
            }
        }

        public async Task<PurchaseUpdateDTO> GetPurchaseById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<PurchaseUpdateDTO>($"api/Purchase/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<PurchaseDTO>> GetPurchaseAsync()
        {
            try
            {
                var data = await _httpClient.GetFromJsonAsync<List<PurchaseDTO>>("api/Purchase");
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

        public async Task<PurchaseUpdateDTO> UpdatePurchaseAsync(int purchaseId, PurchaseUpdateDTO updatePurchase)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<PurchaseUpdateDTO>($"api/Purchase/{purchaseId}", updatePurchase);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PurchaseUpdateDTO>();
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
