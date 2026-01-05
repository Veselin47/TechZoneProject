namespace TechZone.Web.ViewModels.Product
{
    public class ProductCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!; 
        public bool IsAvailable => StockQuantity > 0;
        public int StockQuantity { get; set; }
    }
}