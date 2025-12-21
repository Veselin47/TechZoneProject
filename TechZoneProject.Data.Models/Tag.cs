namespace TechZoneProject.Data.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}