using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorUI.Services.Contracts;
using IMS.MODELS.SaleDTO;

namespace BlazorUI.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly HttpClient _httpClient;

        public SaleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddPurchaseAsync(SaleDTO dto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Sale", dto);
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
                await _httpClient.DeleteAsync($"api/Sale/{id}");
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

        public async Task<SaleUpdateDTO> GetPurchaseById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<SaleUpdateDTO>($"/api/Sale/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<SaleDTO>> GetSaleAsync()
        {
            try
            {
                var data = await _httpClient.GetFromJsonAsync<List<SaleDTO>>("api/Sale");
                return data ?? new List<SaleDTO>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<SaleUpdateDTO> UpdatePurchaseAsync(int id, SaleUpdateDTO dto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<SaleUpdateDTO>($"api/Sale/{id}", dto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<SaleUpdateDTO>();
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
