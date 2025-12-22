using System.ComponentModel.DataAnnotations;

namespace TechZone.Web.ViewModels.Admin.Models
{
    public class ProductInputModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Име на продукта")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 100000)]
        [Display(Name = "Цена (лв.)")]
        public decimal Price { get; set; }

        [Required]
        [Url]
        [Display(Name = "Линк към снимка")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Производител (ID)")]
        public int BrandId { get; set; } // Ще избираме от падащо меню
        // НОВО: Добавяме Наличност
        [Required]
        [Range(0, 10000)]
        [Display(Name = "Наличност (брой)")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Гаранцията е задължителна")]
        [Range(1, 120, ErrorMessage = "Гаранцията трябва да е между 1 и 120 месеца")]
        [Display(Name = "Гаранция (месеци)")]
        public int WarrantyMonths { get; set; }

        public IEnumerable<KeyValuePair<string, string>>? Brands { get; set; }

    }
}

