using TechZone.Web.ViewModels.Home;

namespace TechZone.Services.Data.Interfaces
{
    public interface IProductService
    {
        
        Task<IEnumerable<ProductIndexViewModel>> GetLastProductsAsync(int count);
        Task<IEnumerable<ProductIndexViewModel>> GetProductsByCategoryAsync(string categoryName);
    }
}