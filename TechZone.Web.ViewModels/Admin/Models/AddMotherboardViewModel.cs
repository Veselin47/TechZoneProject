using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddMotherboardViewModel : ProductInputModel
    {
       

        [Required(ErrorMessage = "Сокетът е задължителен")]
        [StringLength(50)]
        [Display(Name = "Сокет")]
        public string Socket { get; set; } = null!; 

        [Required(ErrorMessage = "Форм-факторът е задължителен")]
        [StringLength(50)]
        [Display(Name = "Форм-фактор")]
        public string FormFactor { get; set; } = null!; 

        [Required(ErrorMessage = "Чипсетът е задължителен")]
        [StringLength(50)]
        [Display(Name = "Чипсет")]
        public string Chipset { get; set; } = null!; 

        [Required]
        [Range(1, 8, ErrorMessage = "Слотовете обикновено са 2, 4 или 8")]
        [Display(Name = "Слотове за памет")]
        public int MemorySlots { get; set; }

        [Required(ErrorMessage = "Типът памет е задължителен")]
        [StringLength(20)]
        [Display(Name = "Тип памет")]
        public string MemoryType { get; set; } = null!; 

        [Display(Name = "Вграден Wi-Fi")]
        public bool HasWifi { get; set; }

    }
}
