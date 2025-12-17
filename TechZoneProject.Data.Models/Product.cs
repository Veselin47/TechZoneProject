namespace TechZoneProject.Data.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public int StockQuantity { get; set; }

        // Foreign Key
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        // Collections
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
        // Добавяме и това, за да знаем продукта в кои поръчки участва (ако се наложи справка)
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}