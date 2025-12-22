using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddMouseViewModel : ProductInputModel
    {
        [Required(ErrorMessage = "DPI е задължителен")]
        [Range(400, 32000, ErrorMessage = "DPI трябва да е между 400 и 32,000")]
        [Display(Name = "Чувствителност (DPI)")]
        public int Dpi { get; set; }

        [Required(ErrorMessage = "Типът сензор е задължителен")]
        [Display(Name = "Тип сензор")]
        public string SensorType { get; set; } = null!; // Optical, Laser

        [Required(ErrorMessage = "Типът на свързване е задължителен")]
        [Display(Name = "Свързване")]
        public string ConnectionType { get; set; } = null!; // USB, Wireless

        [Required(ErrorMessage = "Броят бутони е задължителен")]
        [Range(2, 20, ErrorMessage = "Бутоните обикновено са между 2 и 20")]
        [Display(Name = "Брой бутони")]
        public int ButtonsCount { get; set; }

        [Required(ErrorMessage = "Теглото е задължително")]
        [Range(30, 300, ErrorMessage = "Теглото трябва да е между 30g и 300g")]
        [Display(Name = "Тегло (грама)")]
        public double WeightGrams { get; set; }

        [Required(ErrorMessage = "Цветът е задължителен")]
        [Display(Name = "Цвят")]
        public string Color { get; set; } = null!;
    }
}
