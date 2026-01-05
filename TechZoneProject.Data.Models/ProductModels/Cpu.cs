namespace TechZoneProject.Data.Models
{
    public class Cpu : Product
    {
        public int WarrantyMonths { get; set; }
        public string Socket { get; set; } = null!;
        public int PhysicalCores { get; set; }
        public int LogicalCores { get; set; }
        public double BaseFrequencyGhz { get; set; }
        public double TurboFrequencyGhz { get; set; }
        public string Cache { get; set; } = null!;
        public string Series { get; set; } = null!; 
        public bool HasBoxCooler { get; set; }
    }
}