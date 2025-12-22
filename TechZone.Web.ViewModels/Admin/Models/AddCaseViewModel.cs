using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddCaseViewModel : ProductInputModel
    {
        [Required(ErrorMessage = "Форм-факторът е задължителен")]
        [Display(Name = "Тип кутия (Size)")]
        public string FormFactor { get; set; } = null!; // Mid Tower, Full Tower

        [Required(ErrorMessage = "Поддържаните формати са задължителни")]
        [Display(Name = "Поддържани дънни платки")]
        public string SupportedFormats { get; set; } = null!; // ATX, mATX, Mini-ITX

        [Required(ErrorMessage = "Цветът е задължителен")]
        [Display(Name = "Цвят")]
        public string Color { get; set; } = null!;

        [Display(Name = "Мрежест преден панел (Mesh)")]
        public bool HasMeshFront { get; set; }

       
        [Required]
        [Range(100, 1000, ErrorMessage = "Дължината трябва да е между 100 и 1000 mm")]
        [Display(Name = "Дължина (mm)")]
        public double LengthMm { get; set; }

        [Required]
        [Range(100, 500, ErrorMessage = "Ширината трябва да е между 100 и 500 mm")]
        [Display(Name = "Ширина (mm)")]
        public double WidthMm { get; set; }

        [Required]
        [Range(100, 1000, ErrorMessage = "Височината трябва да е между 100 и 1000 mm")]
        [Display(Name = "Височина (mm)")]
        public double HeightMm { get; set; }
    }
}
