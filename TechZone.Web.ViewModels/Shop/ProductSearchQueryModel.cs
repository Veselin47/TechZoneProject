namespace TechZone.Web.ViewModels.Shop
{
    using System.ComponentModel.DataAnnotations;

    public class ProductSearchQueryModel
    {
       
        public int CurrentPage { get; set; } = 1;

    
        public string SearchTerm { get; set; }

        public string Brand { get; set; }

       
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int Sorting { get; set; }
        public string StorageType { get; set; } 

       
        public int? MemorySize { get; set; }
    }
}