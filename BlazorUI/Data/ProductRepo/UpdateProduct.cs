using BlazorUI.Services.Contracts;
using IMS.MODELS.ProductDTO;
using Microsoft.AspNetCore.Components;
namespace BlazorUI.Data.ProductRepo
{
    public class UpdateProductBase : ComponentBase 
    {
        [Inject]
        protected IProductService productRepo { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected ProductUpdateDTO productDto = new ProductUpdateDTO();
        
        [Parameter]
        public int ProductId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                productDto = await productRepo.GetProductById(ProductId);
            }
            catch (Exception ex)
            {
          
                Console.WriteLine($"Error in OnInitializedAsync: {ex.Message}");
            }
        }


        public async Task UpdateProduct()
        {
            try
            {
                productDto = await productRepo.UpdateProductAsync(ProductId, productDto);
                NavigationManager.NavigateTo("/products");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error in UpdateEmployee: {ex.Message}");
            }
        }
    }
}
