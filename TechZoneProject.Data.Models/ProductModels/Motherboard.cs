namespace TechZoneProject.Data.Models
{
    public class Motherboard : Product
    {
        public int WarrantyMonths { get; set; }
        public string Socket { get; set; } = null!;
        public string FormFactor { get; set; } = null!;
        public string Chipset { get; set; } = null!;
        public int MemorySlots { get; set; }
        public string MemoryType { get; set; } = null!; 
        public bool HasWifi { get; set; }
    }
}