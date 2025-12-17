namespace TechZoneProject.Data.Models
{
    public class Mouse : Product
    {
        public int WarrantyMonths { get; set; }
        public int Dpi { get; set; }
        public string SensorType { get; set; } = null!; // Optical
        public string ConnectionType { get; set; } = null!; // USB, Wireless
        public int ButtonsCount { get; set; }
        public double WeightGrams { get; set; }
        public string Color { get; set; } = null!;
    }
}