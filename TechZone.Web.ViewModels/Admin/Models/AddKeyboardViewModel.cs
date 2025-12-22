using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddKeyboardViewModel : ProductInputModel
    {
        [Required(ErrorMessage = "Типът на суичовете е задължителен")]
        [Display(Name = "Тип суичове (Switch Type)")]
        public string SwitchType { get; set; } = null!; // Mechanical, Membrane, Optical

        [Required(ErrorMessage = "Подредбата е задължителна")]
        [Display(Name = "Подредба (Layout)")]
        public string Layout { get; set; } = null!; // US, UK, BG Phonetic

        [Required(ErrorMessage = "Размерът е задължителен")]
        [Display(Name = "Размер (Form Factor)")]
        public string SizePercentage { get; set; } = null!; // 100% Full, TKL 80%, 60%

        [Required(ErrorMessage = "Типът свързване е задължителен")]
        [Display(Name = "Свързване")]
        public string ConnectionType { get; set; } = null!; // Wired USB, Wireless, Bluetooth

        [Display(Name = "RGB Подсветка")]
        public bool HasRgb { get; set; }
    }
}
