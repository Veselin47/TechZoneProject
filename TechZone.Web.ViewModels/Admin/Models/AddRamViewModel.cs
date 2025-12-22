using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddRamViewModel : ProductInputModel
    {
        [Required(ErrorMessage = "Капацитетът е задължителен")]
        [Range(2, 512, ErrorMessage = "Капацитетът трябва да е между 2 и 512 GB")]
        [Display(Name = "Капацитет (GB)")]
        public int CapacityGb { get; set; }

        [Required(ErrorMessage = "Типът е задължителен")]
        [Display(Name = "Тип памет")]
        public string Type { get; set; } = null!; // DDR4, DDR5

        [Required(ErrorMessage = "Скоростта е задължителна")]
        [Range(1000, 10000, ErrorMessage = "Скоростта трябва да е реална (напр. 3200, 5600, 6000)")]
        [Display(Name = "Скорост (MT/s)")]
        public int SpeedMt { get; set; }

        [Required(ErrorMessage = "Таймингът е задължителен")]
        [StringLength(20)]
        [Display(Name = "Тайминг (Latency)")]
        public string Timing { get; set; } = null!; // CL16, CL36, CL40

        [Required(ErrorMessage = "Цветът е задължителен")]
        [Display(Name = "Цвят")]
        public string Color { get; set; } = null!;

        [Display(Name = "Комплект (Kit)")]
        public bool IsKit { get; set; } // Дали са 2 плочки или 1

        [Display(Name = "RGB Осветление")]
        public bool HasRgb { get; set; }

        [Display(Name = "Охладител (Heatsink)")]
        public bool HasHeatsink { get; set; }
    }
}
