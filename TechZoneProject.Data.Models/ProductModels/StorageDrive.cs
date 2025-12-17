namespace TechZoneProject.Data.Models
{
    public class StorageDrive : Product
    {
        public int WarrantyMonths { get; set; }
        public string Type { get; set; } = null!; // NVMe, SSD, HDD
        public string Interface { get; set; } = null!; // PCIe 4.0
        public string FormFactor { get; set; } = null!; // M.2 2280
        public int CapacityGb { get; set; }
        public int ReadSpeedMb { get; set; }
        public int WriteSpeedMb { get; set; }
    }
}