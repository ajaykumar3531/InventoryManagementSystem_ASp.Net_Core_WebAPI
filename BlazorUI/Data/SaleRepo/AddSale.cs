using BlazorUI.Services.Contracts;
using IMS.MODELS.SaleDTO;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.SaleRepo
{
    public class AddSaleBase : ComponentBase
    {
        [Inject]
        protected ISaleService _saleRepo { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected SaleDTO saleDto = new SaleDTO();

        protected override async Task OnInitializedAsync()
        {
            await AddSale();
        }

        protected async Task AddSale()
        {
            var success = await _saleRepo.AddPurchaseAsync(saleDto);
            if (success)
            {
                NavigationManager.NavigateTo("/sales");
            }
        }
    }
}
