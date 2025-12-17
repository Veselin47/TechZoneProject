namespace TechZoneProject.Data.Models

{
    public class Ram : Product
    {
        public int WarrantyMonths { get; set; }
        public int CapacityGb { get; set; }
        public string Type { get; set; } = null!; // DDR5
        public int SpeedMt { get; set; }
        public string Timing { get; set; } = null!; // CL40
        public bool IsKit { get; set; }
        public bool HasRgb { get; set; }
        public bool HasHeatsink { get; set; }
        public string Color { get; set; } = null!;
    }
}