using BlazorUI.Services.Contracts;
using IMS.MODELS.ProductDTO;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Data.ProductRepo
{
    public class LoadProductsBase : ComponentBase
    {
        [Inject]
        protected IProductService _productService { get; set; }
        protected List<ProductDTO> Products { get; set; } = new List<ProductDTO>();

        protected override async Task OnInitializedAsync()
        {
            await LoadProducts();
        }

        protected async Task LoadProducts()
        {
            Products = await _productService.GetProductsAsync();
         
        }

        public async Task Delete(int ProductId)
        {
            var data = await _productService.DeleteProductAsync(ProductId);
            await LoadProducts(); 
        }
    }
}
