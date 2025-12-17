namespace TechZoneProject.Data.Models
{
    public class PowerSupply : Product
    {
        public int WarrantyMonths { get; set; }
        public int PowerWatts { get; set; }
        public string Certification { get; set; } = null!; // 80+ Gold
        public bool IsModular { get; set; }
        public string FormFactor { get; set; } = null!; // ATX
        public string Standard { get; set; } = null!; // ATX 3.1
    }
}