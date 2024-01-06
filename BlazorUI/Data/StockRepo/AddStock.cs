using BlazorUI.Services.Contracts;
using IMS.MODELS.StockDTO;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.StockRepo
{
    public class AddStockBase : ComponentBase
    {
        [Inject]
        protected IStockService _stockRepo { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected StockDTO stockDto = new StockDTO();

        protected override async Task OnInitializedAsync()
        {
            await AddStock();
        }

        protected async Task AddStock()
        {
            var success = await _stockRepo.AddStockAsync(stockDto);
            if (success)
            {
                NavigationManager.NavigateTo("/stocks");
            }
        }
    }
}
