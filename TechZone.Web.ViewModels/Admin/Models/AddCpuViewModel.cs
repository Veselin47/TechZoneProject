using System.ComponentModel.DataAnnotations;

namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddCpuViewModel : ProductInputModel
    {
        [Required]
        [Display(Name = "Серия (напр. Ryzen 7, Core i9)")]
        public string Series { get; set; }

        [Required]
        [Display(Name = "Сокет (напр. AM5, LGA1700)")]
        public string Socket { get; set; }

        [Required]
        [Range(1, 128)]
        [Display(Name = "Физически Ядра")]
        public int PhysicalCores { get; set; }

        [Required]
        [Range(1, 256)]
        [Display(Name = "Логически Ядра (Threads)")]
        public int LogicalCores { get; set; }

        [Required]
        [Display(Name = "Базова Честота (GHz)")]
        public double BaseFrequencyGhz { get; set; }

        [Required]
        [Display(Name = "Турбо Честота (GHz)")]
        public double TurboFrequencyGhz { get; set; }

        [Required]
        [Display(Name = "Кеш Памет (напр. 32MB L3)")]
        public string Cache { get; set; }

        [Required]
        [Range(1, 120)]
        [Display(Name = "Гаранция (месеци)")]
        public int WarrantyMonths { get; set; }

        [Display(Name = "Има ли охладител в кутията?")]
        public bool HasBoxCooler { get; set; }
    }
}
