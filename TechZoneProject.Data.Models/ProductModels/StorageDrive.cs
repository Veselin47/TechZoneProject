namespace TechZoneProject.Data.Models
{
    public class StorageDrive : Product
    {
        public int WarrantyMonths { get; set; }
        public string Type { get; set; } = null!; 
        public string Interface { get; set; } = null!; 
        public string FormFactor { get; set; } = null!; 
        public int CapacityGb { get; set; }
        public int ReadSpeedMb { get; set; }
        public int WriteSpeedMb { get; set; }
    }
}