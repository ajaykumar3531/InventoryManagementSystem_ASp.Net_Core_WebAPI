using BlazorUI.Services.Contracts;
using IMS.MODELS.SaleDTO;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorUI.Data.SaleRepo
{
    public class LoadSaleBase : ComponentBase
    {
        [Inject]
        protected ISaleService _saleService { get; set; }

        protected List<SaleDTO> Sales { get; set; } = new List<SaleDTO>();

        protected override async Task OnInitializedAsync()
        {
            await LoadSales();
        }

        protected async Task LoadSales()
        {
            Sales = await _saleService.GetSaleAsync();
        }

        public async Task Delete(int saleId)
        {
            var data = await _saleService.DeletePurchaseAsync(saleId);
            await LoadSales();
        }
    }
}
