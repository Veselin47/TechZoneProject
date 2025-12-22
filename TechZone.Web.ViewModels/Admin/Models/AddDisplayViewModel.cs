using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddDisplayViewModel : ProductInputModel
    {
        [Required(ErrorMessage = "Размерът на екрана е задължителен")]
        [Range(10, 100, ErrorMessage = "Размерът трябва да е между 10 и 100 инча")]
        [Display(Name = "Размер на екрана (inch)")]
        public double ScreenSizeInch { get; set; }

        [Required(ErrorMessage = "Резолюцията е задължителна")]
        [Display(Name = "Резолюция")]
        public string Resolution { get; set; } = null!; // 1920x1080, 2560x1440

        [Required(ErrorMessage = "Типът на матрицата е задължителен")]
        [Display(Name = "Тип матрица (Panel)")]
        public string PanelType { get; set; } = null!; // IPS, VA, TN, OLED

        [Required(ErrorMessage = "Честотата е задължителна")]
        [Range(30, 1000, ErrorMessage = "Честотата трябва да е между 30Hz и 1000Hz")]
        [Display(Name = "Опресняване (Hz)")]
        public int RefreshRateHz { get; set; }

        [Required(ErrorMessage = "Времето за реакция е задължително")]
        [Range(0, 50, ErrorMessage = "Времето за реакция трябва да е между 0 и 50ms")]
        [Display(Name = "Време за реакция (ms)")]
        public int ResponseTimeMs { get; set; }

        [Required(ErrorMessage = "Портовете са задължителни")]
        [Display(Name = "Портове")]
        public string Ports { get; set; } = null!; // HDMI 2.1, DP 1.4

        [Display(Name = "Извит екран (Curved)")]
        public bool IsCurved { get; set; }
    }
}
