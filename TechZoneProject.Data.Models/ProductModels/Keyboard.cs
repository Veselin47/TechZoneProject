namespace TechZoneProject.Data.Models
{
    public class Keyboard : Product
    {
        public int WarrantyMonths { get; set; }
        public string SwitchType { get; set; } = null!; // Mechanical
        public string Layout { get; set; } = null!; // UK/US
        public bool HasRgb { get; set; }
        public string SizePercentage { get; set; } = null!; // 100%, 60%
        public string ConnectionType { get; set; } = null!; // USB, Wireless
    }
}