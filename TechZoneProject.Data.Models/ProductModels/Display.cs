namespace TechZoneProject.Data.Models
{
    public class Display : Product
    {
        public int WarrantyMonths { get; set; }
        public double ScreenSizeInch { get; set; }
        public string Resolution { get; set; } = null!;
        public string PanelType { get; set; } = null!; // IPS
        public int RefreshRateHz { get; set; }
        public int ResponseTimeMs { get; set; }
        public bool IsCurved { get; set; }
        public string Ports { get; set; } = null!;
    }
}