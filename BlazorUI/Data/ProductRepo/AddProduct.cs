using BlazorUI.Services.Contracts;
using IMS.MODELS.ProductDTO;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.ProductRepo
{
    public class AddProductBase:ComponentBase
    {
        [Inject]
        protected IProductService _productRepo {  get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected ProductDTO productDto = new ProductDTO();

        protected override async Task OnInitializedAsync()
        {
            await AddProduct();
        }

        protected async Task AddProduct()
        {
            var success = await _productRepo.AddProductAsync(productDto);
            if (success)
            {
                NavigationManager.NavigateTo("/products");
            }
        }

    }
}
