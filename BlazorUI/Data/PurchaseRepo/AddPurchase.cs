using BlazorUI.Services.Contracts;
using IMS.MODELS.PurchaseDTO;  // Make sure to use the correct namespace for PurchaseDTO
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.PurchaseRepo
{
    public class AddPurchaseBase : ComponentBase
    {
        [Inject]
        protected IPurchaseService _purchaseRepo { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected PurchaseDTO purchaseDto = new PurchaseDTO();

        protected override async Task OnInitializedAsync()
        {
            await AddPurchase();
        }

        protected async Task AddPurchase()
        {
            var success = await _purchaseRepo.AddPurchaseAsync(purchaseDto);
            if (success)
            {
                NavigationManager.NavigateTo("/purchases");
            }
        }
    }
}
