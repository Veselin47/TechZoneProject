namespace TechZone.Web.ViewModels.Home
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!;

        public bool IsAvailable { get; set; }
    }
}