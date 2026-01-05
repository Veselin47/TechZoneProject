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
        public string SwitchType { get; set; } = null!; 

        [Required(ErrorMessage = "Подредбата е задължителна")]
        [Display(Name = "Подредба (Layout)")]
        public string Layout { get; set; } = null!; 

        [Required(ErrorMessage = "Размерът е задължителен")]
        [Display(Name = "Размер (Form Factor)")]
        public string SizePercentage { get; set; } = null!; 

        [Required(ErrorMessage = "Типът свързване е задължителен")]
        [Display(Name = "Свързване")]
        public string ConnectionType { get; set; } = null!;

        [Display(Name = "RGB Подсветка")]
        public bool HasRgb { get; set; }
    }
}
