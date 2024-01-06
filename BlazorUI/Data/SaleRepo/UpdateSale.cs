using BlazorUI.Services.Contracts;
using IMS.MODELS.SaleDTO;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorUI.Data.SaleRepo
{
    public class UpdateSaleBase : ComponentBase
    {
        [Inject]
        protected ISaleService saleRepo { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected SaleUpdateDTO saleDto = new SaleUpdateDTO();

        [Parameter]
        public int SaleId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                saleDto = await saleRepo.GetPurchaseById(SaleId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnInitializedAsync: {ex.Message}");
            }
        }

        public async Task UpdateSale()
        {
            try
            {
                saleDto = await saleRepo.UpdatePurchaseAsync(SaleId, saleDto);
                NavigationManager.NavigateTo("/sales");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateSale: {ex.Message}");
            }
        }
    }
}
