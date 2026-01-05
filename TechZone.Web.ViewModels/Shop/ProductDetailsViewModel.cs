namespace TechZone.Web.ViewModels.Shop
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Brand { get; set; } = null!;
        public string Category { get; set; } = null!; 

        public Dictionary<string, string> Specifications { get; set; } = new Dictionary<string, string>();
    }
}