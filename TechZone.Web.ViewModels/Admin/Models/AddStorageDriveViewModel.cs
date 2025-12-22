using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddStorageDriveViewModel : ProductInputModel
    {
        [Required(ErrorMessage = "Типът е задължителен")]
        [Display(Name = "Тип устройство")]
        public string Type { get; set; } = null!; // NVMe SSD, SATA SSD, HDD

        [Required(ErrorMessage = "Интерфейсът е задължителен")]
        [Display(Name = "Интерфейс")]
        public string Interface { get; set; } = null!; // PCIe 4.0 x4, SATA III

        [Required(ErrorMessage = "Форм-факторът е задължителен")]
        [Display(Name = "Форм-фактор")]
        public string FormFactor { get; set; } = null!; // M.2 2280, 2.5 inch, 3.5 inch

        [Required(ErrorMessage = "Капацитетът е задължителен")]
        [Range(120, 20000, ErrorMessage = "Капацитетът трябва да е между 120GB и 20TB")]
        [Display(Name = "Капацитет (GB)")]
        public int CapacityGb { get; set; }

        [Range(0, 15000)]
        [Display(Name = "Скорост на четене (MB/s)")]
        public int ReadSpeedMb { get; set; }

        [Range(0, 15000)]
        [Display(Name = "Скорост на писане (MB/s)")]
        public int WriteSpeedMb { get; set; }
    }
}
