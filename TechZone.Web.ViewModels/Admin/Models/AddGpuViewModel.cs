using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZone.Web.ViewModels.Admin.Models
{
    public class AddGpuViewModel : ProductInputModel
    {
        

        [Required]
        [Range(1, 48)]
        [Display(Name = "Памет (GB)")]
        public int MemorySizeGb { get; set; }

        [Required]
        [Display(Name = "Тип Памет")]
        public string MemoryType { get; set; } = null!; 

        [Range(1, 20000)]
        [Display(Name = "CUDA Ядра / Stream Processors")]
        public int CudaCores { get; set; }

        [Range(32, 512)]
        [Display(Name = "Шина (bits)")]
        public int BusWidthBit { get; set; }

        [Range(100, 5000)]
        [Display(Name = "Честота (MHz)")]
        public int FrequencyMhz { get; set; }

        [Required]
        [Display(Name = "Конектори")]
        public string Connectors { get; set; } = null!; 

    }
}
