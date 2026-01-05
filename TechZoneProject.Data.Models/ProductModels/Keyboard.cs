namespace TechZoneProject.Data.Models
{
    public class Keyboard : Product
    {
        public int WarrantyMonths { get; set; }
        public string SwitchType { get; set; } = null!; 
        public string Layout { get; set; } = null!; 
        public bool HasRgb { get; set; }
        public string SizePercentage { get; set; } = null!; 
        public string ConnectionType { get; set; } = null!; 
    }
}