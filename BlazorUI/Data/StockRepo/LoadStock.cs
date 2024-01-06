using BlazorUI.Services.Contracts;
using IMS.DL.Entities;
using IMS.MODELS.StockDTO;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.StockRepo
{
    public class LoadStockBase : ComponentBase
    {
        [Inject]
        protected IStockService _stockService { get; set; }
        protected List<Stock> Stocks { get; set; } = new List<Stock>();

        protected override async Task OnInitializedAsync()
        {
            await LoadStocks();
        }

        protected async Task LoadStocks()
        {
            Stocks = await _stockService.GetStockAsync();
        }

        public async Task Delete(int stockId)
        {
            var data = await _stockService.DeleteStockAsync(stockId);
            await LoadStocks();
        }
    }
}
