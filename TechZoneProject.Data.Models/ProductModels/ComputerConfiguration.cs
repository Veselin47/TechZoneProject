namespace TechZoneProject.Data.Models
{
    public class ComputerConfiguration : Product
    {
        public int WarrantyMonths { get; set; }
        public string CpuModel { get; set; } = null!;
        public string GpuModel { get; set; } = null!;
        public string RamAmount { get; set; } = null!;
        public string SsdAmount { get; set; } = null!;
        public bool HasOs { get; set; }
    }
}