using BlazorUI.Services.Contracts;
using IMS.MODELS.PurchaseDTO;  // Make sure to use the correct namespace for PurchaseUpdateDTO
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.PurchaseRepo
{
    public class UpdatePurchaseBase : ComponentBase
    {
        [Inject]
        protected IPurchaseService _purchaseService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected PurchaseUpdateDTO purchaseDto = new PurchaseUpdateDTO();

        [Parameter]
        public int PurchaseId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                purchaseDto = await _purchaseService.GetPurchaseById(PurchaseId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnInitializedAsync: {ex.Message}");
            }
        }

        public async Task UpdatePurchase()
        {
            try
            {
                purchaseDto = await _purchaseService.UpdatePurchaseAsync(PurchaseId, purchaseDto);
                NavigationManager.NavigateTo("/purchases");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdatePurchase: {ex.Message}");
            }
        }
    }
}
