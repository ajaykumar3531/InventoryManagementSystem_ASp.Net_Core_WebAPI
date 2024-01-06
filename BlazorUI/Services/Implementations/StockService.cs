using BlazorUI.Services.Contracts;
using IMS.DL.Entities;
using IMS.MODELS.StockDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorUI.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddStockAsync(StockDTO stockDto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Stock", stockDto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding stock: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteStockAsync(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Stock/{id}");
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting stock: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error deleting stock: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Stock>> GetStockAsync()
        {
            try
            {
                var data = await _httpClient.GetFromJsonAsync<List<Stock>>("api/Stock");
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

        public async Task<StockUpdateDTO> GetStockById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<StockUpdateDTO>($"/api/Stock/{id}");

            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<StockUpdateDTO> UpdateStockAsync(int stockId, StockUpdateDTO updateStock)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<StockUpdateDTO>($"api/Stock/{stockId}", updateStock);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StockUpdateDTO>();
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
