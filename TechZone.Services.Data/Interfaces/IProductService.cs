using TechZone.Web.ViewModels.Home;
using TechZone.Web.ViewModels.Shop;

namespace TechZone.Services.Data.Interfaces
{
    public interface IProductService
    {
        
        Task<IEnumerable<ProductIndexViewModel>> GetLastProductsAsync(int count);
        Task<IEnumerable<ProductIndexViewModel>> GetProductsByCategoryAsync(string categoryName);
        Task<AllProductsViewModel> GetFilteredProductsAsync(string category, ProductSearchQueryModel query);
        Task<ProductDetailsViewModel> GetProductDetailsAsync(int id);
    }
}