using TechZone.Web.ViewModels.Home; 

namespace TechZone.Web.ViewModels.Shop
{
    public class AllProductsViewModel
    {
        public string CategoryName { get; set; } = null!;

        // Списъкът с намерените продукти
        public IEnumerable<ProductIndexViewModel> Products { get; set; }
            = new List<ProductIndexViewModel>();

        // Списък с всички налични марки в тази категория (за падащото меню)
        public IEnumerable<string> Brands { get; set; }
            = new List<string>();

        // Запазваме какво е търсил потребителя, за да не се изгуби след рефреш
        public ProductSearchQueryModel SearchQuery { get; set; }
            = new ProductSearchQueryModel();
    }
}