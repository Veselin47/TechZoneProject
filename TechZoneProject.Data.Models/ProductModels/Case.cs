namespace TechZoneProject.Data.Models
{
    public class Case : Product
    {
        public int WarrantyMonths { get; set; }
        public string FormFactor { get; set; } = null!; // Mid Tower
        public string SupportedFormats { get; set; } = null!; // ATX, mATX
        public bool HasMeshFront { get; set; }
        public string Color { get; set; } = null!;
        public double LengthMm { get; set; }
        public double WidthMm { get; set; }
        public double HeightMm { get; set; }
    }
}