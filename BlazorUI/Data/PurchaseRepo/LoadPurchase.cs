using BlazorUI.Services.Contracts;
using IMS.MODELS.PurchaseDTO;  // Make sure to use the correct namespace for PurchaseDTO
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.PurchaseRepo
{
    public class LoadPurchaseBase : ComponentBase
    {
        [Inject]
        protected IPurchaseService _purchaseService { get; set; }
        protected List<PurchaseDTO> Purchases { get; set; } = new List<PurchaseDTO>();

        protected override async Task OnInitializedAsync()
        {
            await LoadPurchases();
        }

        protected async Task LoadPurchases()
        {
            Purchases = await _purchaseService.GetPurchaseAsync();
        }

        public async Task Delete(int purchaseId)
        {
            var data = await _purchaseService.DeletePurchaseAsync(purchaseId);
            await LoadPurchases();
        }
    }
}
