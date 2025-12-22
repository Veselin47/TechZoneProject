using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddPowerSupplyViewModel : ProductInputModel
    {
        

        [Required(ErrorMessage = "Мощността е задължителна")]
        [Range(200, 2000, ErrorMessage = "Мощността трябва да е между 200W и 2000W")]
        [Display(Name = "Мощност (Watts)")]
        public int PowerWatts { get; set; }

        [Required(ErrorMessage = "Сертификатът е задължителен")]
        [Display(Name = "80+ Сертификат")]
        public string Certification { get; set; } = null!; // 80+ Gold, Platinum и т.н.

        [Display(Name = "Модулно захранване")]
        public bool IsModular { get; set; }

        [Required(ErrorMessage = "Форм-факторът е задължителен")]
        [Display(Name = "Форм-фактор")]
        public string FormFactor { get; set; } = null!; // ATX, SFX

        [Required(ErrorMessage = "Стандартът е задължителен")]
        [Display(Name = "Стандарт")]
        public string Standard { get; set; } = null!; // ATX 3.0, ATX 2.4

    }
}
