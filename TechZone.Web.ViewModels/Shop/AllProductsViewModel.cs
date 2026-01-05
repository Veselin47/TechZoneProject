using TechZone.Web.ViewModels.Home; 

namespace TechZone.Web.ViewModels.Shop
{
    public class AllProductsViewModel
    {
        public string CategoryName { get; set; } = null!;

        
        public IEnumerable<ProductIndexViewModel> Products { get; set; }
            = new List<ProductIndexViewModel>();

     
        public IEnumerable<string> Brands { get; set; }
            = new List<string>();

        public ProductSearchQueryModel SearchQuery { get; set; }
            = new ProductSearchQueryModel();
    }
}