using BlazorUI.Services.Contracts;
using IMS.MODELS.StockDTO;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorUI.Data.StockRepo
{
    public class UpdateStockBase : ComponentBase
    {
        [Inject]
        protected IStockService _stockService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected StockUpdateDTO stockDto = new StockUpdateDTO();

        [Parameter]
        public int StockId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                stockDto = await _stockService.GetStockById(StockId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnInitializedAsync: {ex.Message}");
            }
        }

        public async Task UpdateStock()
        {
            try
            {
                stockDto = await _stockService.UpdateStockAsync(StockId, stockDto);
                NavigationManager.NavigateTo("/stocks");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateStock: {ex.Message}");
            }
        }
    }
}
